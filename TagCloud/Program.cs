using System.Collections.Generic;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace TagCloud
{
    public class Program
    {
        private static void Main(string[] argv)
        {
            var args = new MainArgs(argv);
            ProcessArguments(args);
        }

        private static void ProcessArguments(MainArgs args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<WordVisualizer>().ImplementedBy<WordVisualizer>());
            container.Register(Component.For<ICloudLayouter>().ImplementedBy<CloudLayouter>());
            container.Register(Component.For<ICloudVisualizer>().ImplementedBy<CloudVisualizer>()
                .DependsOn(Dependency.OnValue<string>(args.ArgImagePath)));
            container.Register(Component.For<ITextAnalyzer>()
                .ImplementedBy<TextAnalyzer>()
                .DependsOn(Dependency.OnValue("text", new StreamWordSource(new StreamReader(args.ArgSourcePath))))
                .DependsOn(Dependency.OnValue("stopWords", new StreamWordSource(new StreamReader(args.ArgStopwordsPath)))));
            container.Register(Component.For<IEnumerable<IPlacementStrategy>>().Instance(new List<IPlacementStrategy>
                {new SpiralStrategy(), new CenterMoveStrategy()}));
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            var visualizer = container.Resolve<WordVisualizer>();
            visualizer.CreateCloudImage(args.OptTextColor, args.OptBackgroundColor, args.OptFont, args.OptImageSize);
        }
    }
}

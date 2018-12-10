using System.Collections.Generic;
using System.Linq;
using NHunspell;

namespace TagCloud
{
    public class TextAnalyzer
    {
        private readonly string[] stopWords;
        private readonly string[] partsOfSpeech;
        private readonly bool useStems;
        public string Text { get; }
        public readonly Dictionary<string, int> WordFrequencies = new Dictionary<string, int>();

        public TextAnalyzer(string text, string[] stopWords, string[] partsOfSpeech = null, bool useStems = false)
        {
            this.stopWords = stopWords;
            this.partsOfSpeech = partsOfSpeech;
            this.useStems = useStems;
            Text = text;
            Analyze();
        }

        private void Analyze()
        {
            var words = Text.Split().Where(w => !stopWords.Contains(w)).Select(w => w.ToLowerInvariant());
            foreach (var word in words)
            {
                if (!WordFrequencies.ContainsKey(word))
                    WordFrequencies[word] = 0;
                WordFrequencies[word]++;
            }
        }
    }
}

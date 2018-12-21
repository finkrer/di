using System.Drawing;

namespace TagCloud
{
    public interface ICloudVisualizer
    {
        void AddWord(Word word, Rectangle position, Font font);
        Bitmap CreateImage(Color textColor, Color backgroundColor, Size? size);
    }
}
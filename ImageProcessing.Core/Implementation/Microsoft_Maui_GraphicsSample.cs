using ImageProcessing.Core.Interface;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace ImageProcessing.Core.Implementation
{
    public class Microsoft_Maui_GraphicsSample : IImageLibFunc
    {
        public Stream FormatConvert(Stream srcStream, string targetFormat, float scale)
        {
            return FormatConvert(srcStream, targetFormat, scale, scale);
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, float hScale, float vScale)
        {
            throw new NotImplementedException();
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height)
        {
            throw new NotImplementedException();
        }

        public void Sample1()
        {
            using var imgStream = File.OpenRead("lenna.png");
            var image = SkiaImage.FromStream(imgStream);
            var newImage = image.Resize(1000, 1000);
            using var output = File.OpenWrite("lenna_Microsoft_Maui_Graphics.png");

            // crash!!!!TODO
            newImage.Save(output);
        }
    }
}
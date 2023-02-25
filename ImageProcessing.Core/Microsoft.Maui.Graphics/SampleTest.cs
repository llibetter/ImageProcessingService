using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

namespace ImageProcessing.Core.Microsoft.Maui.Graphics
{
    public class SampleTest
    {
        public void Sample1()
        {
            using var imgStream= File.OpenRead("lenna.png");
            var image = SkiaImage.FromStream(imgStream);
            var newImage = image.Resize(1000, 1000);
            using var output = File.OpenWrite("lenna_Microsoft_Maui_Graphics.png");

            // crash!!!!
            newImage.Save(output);
        }
    }
}
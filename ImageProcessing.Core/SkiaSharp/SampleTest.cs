using SkiaSharp;

namespace ImageProcessing.Core.SkiaSharp
{
    public class SampleTest
    {
        public void Sample1()
        {
            using var input = File.OpenRead("lenna.png");
            using var inputStream = new SKManagedStream(input);
            using var original = SKBitmap.Decode(inputStream);
            using var resized = original.Resize(new SKImageInfo(1000, 1000), SKFilterQuality.High);
            using var image = SKImage.FromBitmap(resized);
            using var output =File.OpenWrite("lenna_skiasharp.png");
            image.Encode(SKEncodedImageFormat.Png, 95).SaveTo(output);
        }
         
    }
}
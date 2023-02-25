using ImageProcessing.Core.Interface;
using SkiaSharp;

namespace ImageProcessing.Core.Implementation
{
    public class SkiaSharpSample : IImageLibFunc
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
            using var input = File.OpenRead("lenna.png");
            using var inputStream = new SKManagedStream(input);
            using var original = SKBitmap.Decode(inputStream);
            using var resized = original.Resize(new SKImageInfo(1000, 1000), SKFilterQuality.High);
            using var image = SKImage.FromBitmap(resized);
            using var output = File.OpenWrite("lenna_skiasharp.png");
            image.Encode(SKEncodedImageFormat.Png, 95).SaveTo(output);
        }

    }
}
using ImageProcessing.Core.Interface;
using ImageProcessing.Core.Utils;
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
            if (srcStream == null || srcStream.Length == 0)
                throw new ArgumentException();

            srcStream.Seek(0, SeekOrigin.Begin);
            using var inputStream = new SKManagedStream(srcStream);
            using var original = SKBitmap.Decode(inputStream);
            using var resized = original.Resize(new SKImageInfo((int)(original.Width*hScale), (int)(original.Height*vScale)), 
                SKFilterQuality.High);
            using var image = SKImage.FromBitmap(resized);

            var res = new MemoryStream();
            var myImageFormat = CommonUtils.GetMyImageFormat(targetFormat);
            //bmp Encode结果为null
            image.Encode(CommonUtils.GetSkiaFormatByMyImageFormat(myImageFormat), 100).SaveTo(res);
            res.Seek(0, SeekOrigin.Begin);
            return res;
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height)
        {
            if (srcStream == null || srcStream.Length == 0)
                throw new ArgumentException();

            srcStream.Seek(0, SeekOrigin.Begin);
            using var inputStream = new SKManagedStream(srcStream);
            using var original = SKBitmap.Decode(inputStream);
            using var resized = original.Resize(new SKImageInfo(wight, height), SKFilterQuality.High);
            using var image = SKImage.FromBitmap(resized);

            var res = new MemoryStream();
            var myImageFormat = CommonUtils.GetMyImageFormat(targetFormat);
            image.Encode(CommonUtils.GetSkiaFormatByMyImageFormat(myImageFormat), 100).SaveTo(res);
            res.Seek(0, SeekOrigin.Begin);
            return res;
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
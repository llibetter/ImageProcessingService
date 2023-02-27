using ImageMagick;
using ImageProcessing.Core.Interface;
using ImageProcessing.Core.Utils;

namespace ImageProcessing.Core.Implementation
{
    public class Magic_NetSample : IImageLibFunc
    {
        public Stream FormatConvert(Stream srcStream, string targetFormat, float scale)
        {
            return FormatConvert(srcStream, targetFormat, scale, scale);
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, float hScale, float vScale)
        {
            if (srcStream == null || srcStream.Position == 0)
                throw new Exception();

            srcStream.Position = 0;
            using var image = new MagickImage(srcStream);
            image.Resize(new Percentage((double)(hScale*100)), new Percentage((double)(vScale*100)));
            var res = new MemoryStream();
            var myImageFormat = CommonUtils.GetMyImageFormat(targetFormat);
            var magicFormat = CommonUtils.GetMagicFormatByMyImageFormat(myImageFormat);
            image.Write(res, magicFormat);
            res.Position = 0;
            return res;
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height)
        {
            if (srcStream == null || srcStream.Position == 0)
                throw new Exception();

            srcStream.Position = 0;
            using var image = new MagickImage(srcStream);
            image.Resize(wight,height);
            var res = new MemoryStream();
            var myImageFormat = CommonUtils.GetMyImageFormat(targetFormat);
            var magicFormat = CommonUtils.GetMagicFormatByMyImageFormat(myImageFormat);
            image.Write(res,magicFormat);
            res.Position = 0;
            return res;
        }

        public void Sample1()
        {
            using var image = new MagickImage("lenna.png");
            var size = new MagickGeometry(1000, 1000);
            // This will resize the image to a fixed size without maintaining the aspect ratio.
            // Normally an image will be resized to fit inside the specified size.
            size.IgnoreAspectRatio = true;

            image.Resize(size);

            // Save the result
            image.Write("lenna_magicnet.png");
        }


    }
}
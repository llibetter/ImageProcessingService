using ImageMagick;
using ImageProcessing.Core.Interface;

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
            throw new NotImplementedException();
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height)
        {
            throw new NotImplementedException();
        }

        public void Sample1()
        {
            using (var image = new MagickImage("lenna.png"))
            {
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
}
using ImageMagick;

namespace ImageProcessing.Core.Magic.Net
{
    public class SampleTest
    {
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
using ImageProcessing.Core.Interface;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessing.Core.Implementation
{
    public class ImageSharpSample : IImageLibFunc
    {
 

        public Stream FormatConvert(Stream srcStream, string targetFormat, float scale)
        {
            return FormatConvert(srcStream,targetFormat,scale,scale);
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
            using var inStream = File.OpenRead("lenna.png");
            using (Image image = Image.Load(inStream))
            {

                image.Mutate(x => x.Resize(1000, 1000));

                image.Save("lenna_imagesharp.png");
            }
        }


    }
}
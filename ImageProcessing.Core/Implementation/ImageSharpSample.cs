using ImageProcessing.Core.Interface;
using ImageProcessing.Core.Utils;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Tiff;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessing.Core.Implementation
{
    public class ImageSharpSample : IImageLibFunc
    {

        #region FormatConvert

        public Stream FormatConvert(Stream srcStream, string targetFormat, float scale)
        {
            return FormatConvert(srcStream, targetFormat, scale, scale);
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, float hScale, float vScale)
        {
            if (srcStream == null || srcStream.Length == 0)
                throw new ArgumentException();

            srcStream.Position = 0;
            using var image = Image.Load(srcStream);
            var wight = image.Width * hScale;
            var height = image.Height * vScale;
            return FormatConvert(image, targetFormat, (int)wight, (int)height);
        }

        public Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height)
        {
            if (srcStream == null || srcStream.Length == 0)
                throw new ArgumentException();

            srcStream.Position = 0;
            using var image = Image.Load(srcStream);
            return FormatConvert(image, targetFormat, wight, height);
        }

        private Stream FormatConvert(Image srcImage, string targetFormat, int wight, int height)
        {
            srcImage.Mutate(x => x.Resize(wight, height));
            var res = new MemoryStream();
            var encoder = GetImageEncoder(targetFormat);
            srcImage.Save(res, encoder);
            res.Position = 0;
            return res;
        }



        #endregion



        private IImageEncoder GetImageEncoder(string targetFormat)
        {
            var myImageFormat = CommonUtils.GetMyImageFormat(targetFormat);
            IImageEncoder res = myImageFormat switch
            {
                MyImageFormat.Tiff => new TiffEncoder { },
                MyImageFormat.Webp => new WebpEncoder { },
                MyImageFormat.Png => new PngEncoder { },
                MyImageFormat.Bmp => new BmpEncoder { },
                MyImageFormat.Jpeg => new JpegEncoder { },
                _ => throw new Exception(),
            };
            return res;
        }




        public void Sample1()
        {
            using var inStream = File.OpenRead("lenna.png");
            using Image image = Image.Load(inStream);

            image.Mutate(x => x.Resize(1000, 1000));

            image.Save("lenna_imagesharp.png");
        }


    }
}
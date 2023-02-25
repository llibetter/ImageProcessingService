using ImageProcessing.Core.Interface;
using ImageProcessing.Core.Utils;
using NetVips;

namespace ImageProcessing.Core.Implementation
{
    public class NetVipsSample : IImageLibFunc
    {

        #region FormatConvert
        public Stream FormatConvert(Stream srcStream, string targetFormat, float scale)
        {
            return FormatConvert(srcStream, targetFormat, scale, scale);
        }
        public Stream FormatConvert(Stream srcStream, string targetFormat, float hScale, float vScale)
        {
            if (srcStream == null || srcStream.Length == 0)
                throw new ArgumentException($"{nameof(srcStream)} error");

            srcStream.Position = 0;
            using var srcImage = Image.NewFromStream(srcStream);
            return FormatConvert(srcImage, targetFormat, hScale, vScale);
        }
        public Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height)
        {
            if (srcStream == null || srcStream.Length == 0)
                throw new ArgumentException($"{nameof(srcStream)} error");

            srcStream.Position = 0;
            using var srcImage = Image.NewFromStream(srcStream);
            var hScale = (float)wight / srcImage.Width;
            var vScale = (float)height / srcImage.Height;
            return FormatConvert(srcImage, targetFormat, hScale, vScale);
        }
        private Stream FormatConvert(Image srcImage, string targetFormat, float hScale, float vScale)
        {
            using var reSizeImage = srcImage.Resize(hScale, vscale: vScale);

            var realTargetFormat = CommonUtils.GetMyImageFormat(targetFormat);
            if (realTargetFormat == MyImageFormat.Tiff)
            {
                var bytes = reSizeImage.TiffsaveBuffer(compression: Enums.ForeignTiffCompression.Lzw, q: 100);
                return new MemoryStream(bytes);
            }
            else if (realTargetFormat == MyImageFormat.Webp)
            {
                byte[] bytes = reSizeImage.WebpsaveBuffer(lossless: false);
                return new MemoryStream(bytes);
            }
            else
            {
                var stream = new MemoryStream();
                var vOption = new VOption
                {
                    { NetVipsVOptionKey.Q, 100 }
                };
                if (realTargetFormat == MyImageFormat.Png)
                {
                    vOption.Add(NetVipsVOptionKey.compression, 1);
                }
                using var resImage = reSizeImage.Copy();
                //不支持.bmp.TODO
                resImage.WriteToStream(stream, CommonUtils.GetExtensionWithDot(realTargetFormat), vOption);
                stream.Position = 0;
                return stream;
            }
        }
        #endregion




        public void Sample1()
        {
            using var im = Image.NewFromFile("lenna.png");
            var hscale = 1000f / im.Width;
            var vscale = 1000f / im.Height;
            using var res = im.Resize(hscale, vscale: vscale);
            res.WriteToFile("lenna_netvips.png");
        }
    }
}
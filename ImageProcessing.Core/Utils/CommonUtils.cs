using ImageMagick;
using SkiaSharp;

namespace ImageProcessing.Core.Utils
{
    public class NetVipsVOptionKey
    {
        public const string Q = nameof(Q);
        public const string compression = nameof(compression);
    }

    public enum MyImageFormat
    {
        Undefined=0,

        Png=1,
        Bmp=2,
        Tiff=3,
        Jpeg=5,
        Webp=6,

        Svg=7,
        Ai=8
    }

    public class CommonUtils
    {
        public static MyImageFormat GetMyImageFormat(string targetFormat)
        {
            if (string.IsNullOrWhiteSpace(targetFormat))
                throw new ArgumentException();

            var res=targetFormat.ToLower().Trim('.') switch
            {
                "png" => MyImageFormat.Png,
                "bmp" => MyImageFormat.Bmp,
                "tif" =>MyImageFormat.Tiff,
                "tiff" => MyImageFormat.Tiff,
                "jpg" => MyImageFormat.Jpeg,
                "jpe" => MyImageFormat.Jpeg,
                "jpeg" => MyImageFormat.Jpeg,
                "webp"=>MyImageFormat.Webp,
                "svg" => MyImageFormat.Svg,
                "ai" => MyImageFormat.Ai,
                _ => throw new ArgumentException("invalid enum value", targetFormat),

            };

            return res;
        }

        public static MagickFormat GetMagicFormatByMyImageFormat(MyImageFormat myImageFormat)
        {
            return myImageFormat switch { 
                MyImageFormat.Svg=> MagickFormat.Svg,
                MyImageFormat.Ai=>MagickFormat.Ai,
                MyImageFormat.Png=>MagickFormat.Png32,
                MyImageFormat.Tiff=>MagickFormat.Tiff,
                MyImageFormat.Webp=>MagickFormat.WebP,
                MyImageFormat.Jpeg=>MagickFormat.Jpeg,
                MyImageFormat.Bmp=>MagickFormat.Bmp,
                _=>throw new Exception(),
            };
        }

        public static SKEncodedImageFormat GetSkiaFormatByMyImageFormat(MyImageFormat myImageFormat)
        {
            //不支持tiff
            return myImageFormat switch {
                MyImageFormat.Png => SKEncodedImageFormat.Png,
                MyImageFormat.Webp => SKEncodedImageFormat.Webp,
                MyImageFormat.Jpeg => SKEncodedImageFormat.Jpeg,
                MyImageFormat.Bmp => SKEncodedImageFormat.Bmp,
                _ => throw new Exception(),
            };
        }
        public static string GetExtensionWithDot(MyImageFormat myImageFormat)
        {
            if (myImageFormat == MyImageFormat.Undefined)
                throw new ArgumentException();

            return $".{myImageFormat}".ToLower();
        }
    }
}

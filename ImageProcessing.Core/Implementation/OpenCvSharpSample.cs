using ImageProcessing.Core.Interface;
using OpenCvSharp;

namespace ImageProcessing.Core.Implementation
{
    public class OpenCvSharpSample : IImageLibFunc
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
            using var src = new Mat("lenna.png", ImreadModes.Color);
            using var dst = new Mat();

            Cv2.Resize(src, dst, new Size(1000, 1000));
            dst.ImWrite("lenna_opencvsharp.png");
        }

        public void Sample2()
        {
            using var src = new Mat("lenna.png", ImreadModes.Grayscale);
            using var dst = new Mat();

            Cv2.Canny(src, dst, 50, 200);
            using (new Window("src image", src))
            using (new Window("dst image", dst))
            {
                Cv2.WaitKey();
            }
        }

        public void Sample3()
        {
            using (var t = new ResourcesTracker())
            {
                Mat mat1 = t.NewMat(new Size(100, 100), MatType.CV_8UC3, new Scalar(0));
                Mat mat3 = t.T(255 - t.T(mat1 * 0.8));
                Mat[] mats1 = t.T(mat3.Split());
                Mat mat4 = t.NewMat();
                Cv2.Merge(new Mat[] { mats1[0], mats1[1], mats1[2] }, mat4);
            }

            using (var t = new ResourcesTracker())
            {
                var src = t.T(new Mat(@"lenna.png", ImreadModes.Grayscale));
                var dst = t.NewMat();
                Cv2.Canny(src, dst, 50, 200);
                var blurredDst = t.T(dst.Blur(new Size(3, 3)));
                t.T(new Window("src image", src));
                t.T(new Window("dst image", blurredDst));
                Cv2.WaitKey();
            }
        }
    }
}
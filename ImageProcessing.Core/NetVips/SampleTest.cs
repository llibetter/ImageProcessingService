using NetVips;

namespace ImageProcessing.Core.NetVips
{
    public class SampleTest
    {
        public void Sample1()
        {
            using var im = Image.NewFromFile("lenna.png");
            var hscale = 1000f/im.Width;
            var vscale = 1000f / im.Height;
            using var res = im.Resize(hscale,vscale:vscale);
            res.WriteToFile("lenna_netvips.png");
        }
    }
}
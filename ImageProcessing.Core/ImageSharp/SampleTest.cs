using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessing.Core.ImageSharp
{
    public class SampleTest
    {
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
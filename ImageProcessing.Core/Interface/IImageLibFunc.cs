namespace ImageProcessing.Core.Interface
{
    internal interface IImageLibFunc
    {
        void Sample1();
        Stream FormatConvert(Stream srcStream, string targetFormat, float scale);
        Stream FormatConvert(Stream srcStream, string targetFormat, float hScale, float vScale);
        Stream FormatConvert(Stream srcStream, string targetFormat, int wight, int height);
    }
}

namespace ImageProcessing.Core.Utils
{
    public class FileUtils
    {
        public static Stream LocalFile2Stream(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)
                || !File.Exists(fileName))
                throw new ArgumentException();

            return File.OpenRead(fileName);
        }

        public static void Stream2LocalFile(Stream stream, string fileName)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);

            var fileInfo=new FileInfo(fileName);
            if (!fileInfo.Directory.Exists)
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);
            }

            var fs = new FileStream(fileName, FileMode.Create);
            var bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }
    }
}

using System.IO;
using System.Text;

namespace CodeGenerator.Helpers
{
    public static class Methods
    {
        public static void CreateFile(string content, string path, string fileName)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var filePath = Path.Combine(path, fileName);
            FileStream fs = null;
            try
            {
                if (!File.Exists(filePath))
                {
                    fs = new FileStream(filePath, FileMode.CreateNew);
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        writer.Write(content);
                    }
                }
                else
                {
                    File.Delete(filePath);
                    fs = new FileStream(filePath, FileMode.CreateNew);
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                    {
                        writer.Write(content);
                    }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }
    }
}
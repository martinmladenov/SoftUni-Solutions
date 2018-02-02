namespace _7._Directory_Traversal
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            string path = Console.ReadLine();

            using (var writeStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt", FileMode.Create))
            {
                void WriteLineToFile(string text)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(text + Environment.NewLine);
                    writeStream.Write(bytes, 0, bytes.Length);
                }

                foreach (var filesByExtension in Directory.GetFiles(path)
                    .Select(f => new FileInfo(f))
                    .GroupBy(f => f.Extension)
                    .OrderByDescending(gr => gr.Count())
                    .ThenBy(gr => gr.Key))
                {
                    WriteLineToFile(filesByExtension.Key);
                    foreach (var fileInfo in filesByExtension
                        .OrderBy(fi => fi.Length))
                    {
                        WriteLineToFile($"--{fileInfo.Name} - {Math.Round(fileInfo.Length / 1024d, 3)}kb");
                    }
                }
            }
        }
    }
}

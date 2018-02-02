namespace _8._Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class FullDirectoryTraversal
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

                List<FileInfo> files = new List<FileInfo>();

                AddAllFilesInPath(path, files);

                foreach (var filesByExtension in files
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

        private static void AddAllFilesInPath(string path, List<FileInfo> files)
        {
            files.AddRange(Directory.GetFiles(path).Select(file => new FileInfo(file)));

            foreach (var directory in Directory.GetDirectories(path))
            {
                AddAllFilesInPath(directory, files);
            }
        }
    }
}

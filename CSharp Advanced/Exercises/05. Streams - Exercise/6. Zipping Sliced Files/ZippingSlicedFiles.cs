namespace _6._Zipping_Sliced_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            List<string> parts = Slice("sliceMe.mp4", "", 5);
            Assemble(parts, "");
        }

        private static List<string> Slice(string sourceFile, string destinationDirectory, int parts)
        {
            List<string> files = new List<string>();

            using (var readStream = new FileStream(sourceFile, FileMode.Open))
            {
                long partLength = (long)Math.Ceiling(1.0 * readStream.Length / parts);
                for (int currPart = 0; currPart < parts; currPart++)
                {
                    string fileName = destinationDirectory + "Part-" + currPart + ".gz";

                    files.Add(fileName);

                    long totalCopied = 0;

                    using (var writeStream = new FileStream(fileName, FileMode.Create))
                    {
                        using (var zipStream = new GZipStream(writeStream, CompressionMode.Compress))
                        {
                            while (totalCopied < partLength)
                            {
                                byte[] buffer = new byte[4096];
                                int byteCount = readStream.Read(buffer, 0, 4096);
                                if (byteCount == 0)
                                {
                                    break;
                                }

                                zipStream.Write(buffer, 0, byteCount);
                                totalCopied += 4096;
                            }
                        }
                    }
                }
            }

            return files;
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            using (var writeStream = new FileStream(destinationDirectory + "assembled.mp4", FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (var readStream = new FileStream(file, FileMode.Open))
                    {
                        using (var unzipStream = new GZipStream(readStream, CompressionMode.Decompress))
                        {
                            while (true)
                            {
                                byte[] buffer = new byte[4096];
                                int byteCount = unzipStream.Read(buffer, 0, buffer.Length);
                                if (byteCount == 0)
                                {
                                    break;
                                }

                                writeStream.Write(buffer, 0, byteCount);
                            }
                        }
                    }
                }
            }
        }
    }
}

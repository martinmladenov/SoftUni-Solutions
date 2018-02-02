namespace _4._Copy_Binary_File
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (var readStream = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var writeStream = new FileStream("copied.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int byteCount = readStream.Read(buffer, 0, 4096);
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

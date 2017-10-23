namespace _05.Folder_Size
{
    using System.IO;
    using System.Linq;

    public class FolderSize
    {
        public static void Main()
        {
            long size = Directory.GetFiles(@"..\..\TestFolder")
                .Sum(file => new FileInfo(file).Length);
            File.WriteAllText(@"..\..\Output.txt", ((double)size / 1048576).ToString());
        }
    }
}

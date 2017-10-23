namespace _04.Merge_Files
{
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        public static void Main()
        {
            var list = File.ReadAllLines(@"..\..\FileOne.txt").ToList();
            list.AddRange(File.ReadAllLines(@"..\..\FileTwo.txt"));
            list.Sort();
            File.WriteAllLines(@"..\..\Output.txt", list);
        }
    }
}

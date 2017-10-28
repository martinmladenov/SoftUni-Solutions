namespace _03.Camera_View
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CameraView
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rgx = new Regex($"\\|<.{{{elements[0]}}}([^|]{{0,{elements[1]}}})");
            string line = Console.ReadLine();
            Console.WriteLine(string.Join(", ", rgx.Matches(line)
                .Cast<Match>()
                .Select(m => m.Groups[1])));
        }
    }
}

namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Files
    {
        public static void Main()
        {
            var files = new Dictionary<string, long>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                int separatorIndex = line.LastIndexOf(';');
                files[line.Substring(0, separatorIndex)] = long.Parse(line.Substring(separatorIndex + 1));
            }
            var outSplit = Console.ReadLine().Split();
            string type = outSplit[0];
            string root = outSplit[2];
            bool found = false;
            foreach (var file in files
                .Where(file => file.Key.Split('\\')[0] == root
                   && file.Key.Split('.').Last() == type)
                .OrderByDescending(file => file.Value)
                .ThenBy(file => file.Key.Split('\\').Last()))
            {
                Console.WriteLine($"{file.Key.Split('\\').Last()} - {file.Value} KB");
                found = true;
            }
            if (!found)
                Console.WriteLine("No");
        }
    }
}

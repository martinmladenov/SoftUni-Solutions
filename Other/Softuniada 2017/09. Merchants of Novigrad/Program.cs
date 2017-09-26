using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Merchants_of_Novigrad
{
    class Program
    {

        public static int PathsFound;
        public static Town[] Towns;
        public static List<int> LoopIds = new List<int>();
        public static bool FoundLoop;
        public static bool Infinite;

        static void Main(string[] args)
        {
            var nm = Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int n = nm[0];
            int m = nm[1];

            Towns = new Town[n];
            for (int i = 0; i < n; i++)
                Towns[i] = new Town();

            for (int i = 0; i < m; i++)
            {
                var input = Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), townId => int.Parse(townId) - 1);
                int from = input[0];
                int to = input[1];
                Towns[from].PathsTo.Add(to);
            }
            FindPath(0, new List<int>());
            if (Infinite) return;
            Console.WriteLine("{1} {0}", FoundLoop ? "yes" : "no", PathsFound);
        }

        private static void FindPath(int fromId, List<int> passedIds)
        {
            if (Infinite) return;
            var to = Towns[fromId].PathsTo;
            if (passedIds.Contains(fromId))
            {
                FoundLoop = true;
                bool add = false;
                foreach (int t in passedIds)
                {
                    if (t == fromId) add = true;
                    if (add) LoopIds.Add(t);
                }
                return;
            }
            passedIds.Add(fromId);
            if (fromId == Towns.Length - 1)
            {
                PathsFound++;
                if (!passedIds.Any(i => LoopIds.Contains(i)))
                    return;
                Console.WriteLine("infinite");
                Infinite = true;
                return;
            }
            foreach (var i in to)
                FindPath(i, new List<int>(passedIds));
        }
    }

    class Town
    {
        public List<int> PathsTo { get; set; }

        public Town()
        {
            PathsTo = new List<int>();
        }
    }
}

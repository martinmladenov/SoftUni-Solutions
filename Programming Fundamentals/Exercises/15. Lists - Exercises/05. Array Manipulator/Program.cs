namespace _05.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(long.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "print")
            {
                var split = command.Split();
                switch (split[0])
                {
                    case "add":
                        {
                            var n = int.Parse(split[1]);
                            list.Insert(n, int.Parse(split[2]));
                            break;
                        }
                    case "addMany":
                        {
                            var n = int.Parse(split[1]);
                            list.InsertRange(n, split.Skip(2).Select(long.Parse).ToArray());
                            break;
                        }
                    case "contains":
                        {
                            var n = int.Parse(split[1]);
                            long index = -1;
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] != n) continue;
                                index = i;
                                break;
                            }
                            Console.WriteLine(index);
                            break;
                        }
                    case "remove":
                        {
                            var n = int.Parse(split[1]);
                            list.RemoveAt(n);
                            break;
                        }
                    case "shift":
                        {
                            var n = int.Parse(split[1]);
                            var arr = new long[list.Count];
                            for (int index = 0; index < list.Count; index++)
                            {
                                int targetIndex = index - n;
                                while (targetIndex > arr.Length)
                                    targetIndex -= arr.Length;
                                while (targetIndex < 0)
                                    targetIndex += arr.Length;
                                arr[targetIndex] = list[index];
                            }
                            list = arr.ToList();
                            break;
                        }
                    case "sumPairs":
                        var newList = new List<long>();
                        for (int i = 1; i < list.Count; i += 2)
                        {
                            if (i % 2 == 0) continue;
                            newList.Add(list[i] + list[i - 1]);
                        }
                        if (list.Count % 2 != 0)
                        {
                            newList.Add(list[list.Count - 1]);
                        }
                        list = newList;
                        break;
                }
            }
            Console.WriteLine("[" + string.Join(", ", list) + "]");
        }
    }
}

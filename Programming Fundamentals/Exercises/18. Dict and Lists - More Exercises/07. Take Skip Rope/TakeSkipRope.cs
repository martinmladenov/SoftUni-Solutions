namespace _07.Take_Skip_Rope
{
    using System;
    using System.Linq;

    public static class TakeSkipRope
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            var numbersList = str
                .Where(c => c >= '0' && c <= '9')
                .Select(c => c - '0')
                .ToList();
            var nonNumbersList = str
                .Where(c => c < '0' || c > '9')
                .ToList();
            var takeList = numbersList
                .Where((t, i) => i % 2 == 0)
                .ToList();
            var skipList = numbersList
                .Where((t, i) => i % 2 != 0)
                .ToList();
            string result = string.Empty;
            int currentIndex = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                result += new string(nonNumbersList
                    .Skip(currentIndex)
                    .Take(takeList[i])
                    .ToArray());
                currentIndex += skipList[i] + takeList[i];
            }
            Console.WriteLine(result);
        }
    }
}

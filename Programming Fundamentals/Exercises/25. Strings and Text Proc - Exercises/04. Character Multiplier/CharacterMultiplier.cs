namespace _04.Character_Multiplier
{
    using System;
    using System.Linq;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            var split = Console.ReadLine()
                .Split()
                .OrderByDescending(s => s.Length)
                .ToArray();
            var str1 = split[0];
            var str2 = split[1];
            int sum = 0;
            for (int i = 0; i < str2.Length; i++)
                sum += str1[i] * str2[i];
            for (int i = str2.Length; i < str1.Length; i++)
                sum += str1[i];
            Console.WriteLine(sum);
        }
    }
}

namespace _09.Melrah_Shake
{
    using System;

    public class MelrahShake
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            string pattern = Console.ReadLine();
            while (pattern.Length > 0)
            {
                int index = str.IndexOf(pattern);
                if (index == -1)
                    break;
                str = str.Remove(index, pattern.Length);
                index = str.LastIndexOf(pattern);
                if (index == -1)
                    break;
                str = str.Remove(index, pattern.Length);
                Console.WriteLine("Shaked it.");
                pattern = pattern.Remove(pattern.Length / 2, 1);
            }
            Console.WriteLine("No shake.");
            Console.WriteLine(str);
        }
    }
}

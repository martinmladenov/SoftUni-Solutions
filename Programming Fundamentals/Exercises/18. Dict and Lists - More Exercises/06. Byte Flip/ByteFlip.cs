namespace _06.Byte_Flip
{
    using System;
    using System.Linq;

    public static class ByteFlip
    {
        public static void Main()
        {
            Console.WriteLine(string.Join("",
                Console.ReadLine()
                    .Split()
                    .Where(s => s.Length == 2)
                    .Select(s => new string(s.Reverse().ToArray()))
                    .Reverse()
                    .Select(hex => (char)Convert.ToInt32(hex, 16))
                    ));
        }
    }
}

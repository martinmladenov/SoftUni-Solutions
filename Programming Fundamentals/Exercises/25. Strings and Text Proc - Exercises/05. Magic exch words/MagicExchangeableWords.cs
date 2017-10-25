namespace _05.Magic_exch_words
{
    using System;
    using System.Linq;

    public class MagicExchangeableWords
    {
        public static void Main()
        {
            var split = Console.ReadLine().Split();
            var signature1 = StringSignature(split[0]);
            var signature2 = StringSignature(split[1]);
            bool same;
            if (signature1.Length == signature2.Length)
                same = signature1 == signature2;
            else
            {
                same = new string(signature1.Distinct().ToArray()) == new string(signature2.Distinct().ToArray()); ;
            }
            Console.WriteLine(same ? "true" : "false");
        }

        private static string StringSignature(string s)
        {
            char curr = '\0';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '\0' + s.Length)
                    continue;
                s = s.Replace(s[i], curr);
                curr++;
            }
            return s;
        }
    }
}

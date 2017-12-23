using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Duplicated_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> s = Console.ReadLine().ToList();
            int operations = 0;
            char prev = '-';
            int prevOper = -1;
            while (s.Count > 0 && operations > prevOper)
            {
                prevOper = operations;
                int prevPos = -1;
                for (int i = 0; i < s.Count; i++)
                {
                    char c = s[i];
                    if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z'))
                    {
                        prev = '-';
                        prevPos = -1;
                    }
                    if (prev == c && prevPos != -1)
                    {
                        operations++;
                        s.RemoveAt(i);
                        s.RemoveAt(prevPos);
                        prevPos = -1;
                        prev = '-';
                    }
                    else
                    {
                        prev = c;
                        prevPos = i;
                    }
                }
            }

            if (s.Count > 0)
                foreach (char c in s)
                    Console.Write(c);
            else Console.Write("Empty String");
            Console.WriteLine("\n{0} operations", operations);
            ;
        }
    }
}

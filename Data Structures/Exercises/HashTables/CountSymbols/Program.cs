namespace CountSymbols
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            HashTable<char, int> hashTable = new HashTable<char,int>();

            foreach (char c in input)
            {
                if (hashTable.ContainsKey(c))
                {
                    hashTable[c]++;
                }
                else
                {
                    hashTable[c] = 1;
                }
            }

            foreach (var keyValue in hashTable.OrderBy(kv => kv.Key))
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value} time/s");
            }
        }
    }
}

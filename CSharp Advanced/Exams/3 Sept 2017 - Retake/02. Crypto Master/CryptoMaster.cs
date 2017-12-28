namespace _02.Crypto_Master
{
    using System;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(new[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxLength = 0;
            for (int start = 0; start < arr.Length; start++)
            {
                for (int step = 1; step < arr.Length; step++)
                {
                    int currentLength = 0;
                    int currentPos = start; 
                    do
                    {
                        currentLength++;
                    } while (arr[currentPos % arr.Length]
                        > arr[(currentPos += step) % arr.Length]);
                    if (currentLength > maxLength)
                        maxLength = currentLength;
                }
            }
            Console.WriteLine(maxLength);
        }
    }
}

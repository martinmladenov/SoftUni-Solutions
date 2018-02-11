namespace _03._Crypto_Blockchain
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CryptoBlockchain
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            //char[] blockchainArr = new char[n * 16];

            //for (int i = 0; i < n; i++)
            //{
            //    char[] line = Console.ReadLine().ToCharArray();

            //    for (int j = 0; j < 16; j++)
            //    {
            //        blockchainArr[16 * i + j] = line[j];
            //    }
            //}

            //string blockchain = new string(blockchainArr);

            string blockchain = string.Empty;
            for (int i = 0; i < n; i++)
            {
                blockchain += Console.ReadLine();
            }

            Regex rgx = new Regex(@"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])");

            StringBuilder sb = new StringBuilder();

            foreach (Match match in rgx.Matches(blockchain))
            {
                string digits = match.Groups["digits"].Value;

                if (digits.Length == 0 || digits.Length % 3 != 0)
                {
                    continue;
                }

                for (int numberIndex = 0; numberIndex < digits.Length / 3; numberIndex++)
                {
                    sb.Append((char)(int.Parse(digits.Substring(3 * numberIndex, 3)) - match.Value.Length));
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
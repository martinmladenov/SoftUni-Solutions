namespace _04.Sieve_of_Eratosthenes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var primes = new bool[n + 1];
            for (int i = 2; i <= n; i++)
                primes[i] = true;
            for (int p = 0; p <= n; p++)
            {
                if (!primes[p]) continue;
                Console.Write(p + " ");
                for (int j = 2; j * p <= n; j++)
                {
                    primes[j * p] = false;
                }
            }
        }
    }
}

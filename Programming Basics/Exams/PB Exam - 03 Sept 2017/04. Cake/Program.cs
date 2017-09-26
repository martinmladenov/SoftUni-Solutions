using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Cake
{
    class Program
    {
        static void Main(string[] args)
        {

            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int pieces = width * length;
            string cmd = String.Empty;
            while ((cmd = Console.ReadLine()) != "STOP")
            {
                int piecesToTake = int.Parse(cmd);
                if (piecesToTake > pieces)
                {
                    Console.WriteLine($"No more cake left! You need {piecesToTake - pieces} pieces more.");
                    return;
                }
                pieces -= piecesToTake;
            }
            Console.WriteLine($"{pieces} pieces are left.");

        }
    }
}

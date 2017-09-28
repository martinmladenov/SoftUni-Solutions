using System;

namespace _05.BPM_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int bpm = int.Parse(Console.ReadLine());
            int beats = int.Parse(Console.ReadLine());
            int seconds = 60 * beats / bpm;
            Console.WriteLine("{0} bars - {1}m {2}s", Math.Round(beats/4d,1), seconds/60, seconds%60);
        }
    }
}

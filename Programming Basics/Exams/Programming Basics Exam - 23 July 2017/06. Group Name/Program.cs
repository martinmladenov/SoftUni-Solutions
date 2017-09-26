using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Group_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            char i1 = char.Parse(Console.ReadLine());
            char i2 = char.Parse(Console.ReadLine());
            char i3 = char.Parse(Console.ReadLine());
            char i4 = char.Parse(Console.ReadLine());
            int i5 = int.Parse(Console.ReadLine());

            int counter = 0;

            for (char i1Index = 'A'; i1Index <= i1; i1Index++)
                for (char i2Index = 'a'; i2Index <= i2; i2Index++)
                    for (char i3Index = 'a'; i3Index <= i3; i3Index++)
                        for (char i4Index = 'a'; i4Index <= i4; i4Index++)
                            for (int i5Index = 0; i5Index <= i5; i5Index++)
                            {
                                if (i1Index == i1 &&
                                    i2Index == i2 &&
                                    i3Index == i3 &&
                                    i4Index == i4 &&
                                    i5Index == i5)
                                {
                                    Console.WriteLine(counter);
                                    return;
                                }
                                counter++;

                            }
        }
    }
}

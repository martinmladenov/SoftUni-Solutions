using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class Program
{
    static void Main(string[] args)
    {
        OrderedBag<int> ob = new OrderedBag<int>();
        ob.Add(7);
        ob.Add(5);
        ob.Add(5);
        ob.Add(5);
        ob.Add(1);

        Console.WriteLine(ob.Reversed());
    }
}

namespace ListyIterator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var listyIterator = new ListyIterator<string>(Console.ReadLine().Split().Skip(1));

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    if (input == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (input == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (input == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext);
                    }
                    else if (input == "PrintAll")
                    {
                        Console.WriteLine(string.Join(" ", listyIterator));
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

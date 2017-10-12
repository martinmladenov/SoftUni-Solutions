namespace _02.Change_List
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;
            while ((input = Console.ReadLine()) != "Even" && input != "Odd")
            {
                var commandArr = input.Split();
                switch (commandArr[0])
                {
                    case "Delete":
                        list.RemoveAll(i => i == int.Parse(commandArr[1]));
                        break;

                    case "Insert":
                        list.Insert(int.Parse(commandArr[2]), int.Parse(commandArr[1]));
                        break;
                }
            }
            foreach (var i in list)
            {
                if (i % 2 == (input == "Odd" ? 1 : 0))
                    Console.Write(i + " ");
            }
        }
    }
}

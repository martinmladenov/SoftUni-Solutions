using System;

public class Engine
{
    private CustomList<string> customList;

    public Engine()
    {
        customList = new CustomList<string>();
    }

    public void InterpretCommand(string line)
    {
        string[] split = line.Split();

        string cmd = split[0];

        if (cmd == "Add")
        {
            customList.Add(split[1]);
        }
        else if (cmd == "Remove")
        {
            customList.Remove(int.Parse(split[1]));
        }
        else if (cmd == "Contains")
        {
            Console.WriteLine(customList.Contains(split[1]));
        }
        else if (cmd == "Swap")
        {
            customList.Swap(int.Parse(split[1]), int.Parse(split[2]));
        }
        else if (cmd == "Greater")
        {
            Console.WriteLine(customList.CountGreaterThen(split[1]));
        }
        else if (cmd == "Max")
        {
            Console.WriteLine(customList.Max());
        }
        else if (cmd == "Min")
        {
            Console.WriteLine(customList.Min());
        }
        else if (cmd == "Print")
        {
            foreach (var str in customList)
            {
                Console.WriteLine(str);
            }
        }
        else if (cmd == "Sort")
        {
            Sorter.Sort(customList);
        }
    }
}

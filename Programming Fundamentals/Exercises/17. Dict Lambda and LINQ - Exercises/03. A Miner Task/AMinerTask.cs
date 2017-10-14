namespace _03.A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    public static class AMinerTask
    {
        public static void Main()
        {
            var resources = new Dictionary<string, long>();
            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;
                int quantity = int.Parse(Console.ReadLine());
                if (resources.ContainsKey(resource))
                    resources[resource] += quantity;
                else
                    resources[resource] = quantity;
            }
            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}

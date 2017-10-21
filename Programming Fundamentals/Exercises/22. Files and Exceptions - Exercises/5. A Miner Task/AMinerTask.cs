namespace _5.A_Miner_Task
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class AMinerTask
    {
        public static void Main()
        {
            var resources = new Dictionary<string, long>();
            var input = File.ReadAllLines("input.txt");
            for (var i = 0; i < input.Length; i += 2)
            {
                var resource = input[i];
                if (resource == "stop")
                    break;
                int quantity = int.Parse(input[i + 1]);
                if (resources.ContainsKey(resource))
                    resources[resource] += quantity;
                else
                    resources[resource] = quantity;
            }
            var output = resources
                .Select(resource
                    => $"{resource.Key} -> {resource.Value}")
                .ToList();
            File.WriteAllLines("output.txt", output);
        }
    }
}

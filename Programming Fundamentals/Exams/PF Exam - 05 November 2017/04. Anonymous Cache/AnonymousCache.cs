namespace _04.Anonymous_Cache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AnonymousCache
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, int>>();
            var cache = new Dictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                if (input.Contains("->"))
                {
                    var split = input.Split(new[] { ' ', '-', '>', '|' },
                        StringSplitOptions.RemoveEmptyEntries);
                    string dataKey = split[0];
                    string dataSet = split[2];
                    int dataSize = int.Parse(split[1]);
                    if (data.ContainsKey(dataSet))
                    {
                        data[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        if (!cache.ContainsKey(dataSet))
                            cache[dataSet] = new Dictionary<string, int>();
                        cache[dataSet][dataKey] = dataSize;
                    }
                }
                else if (!data.ContainsKey(input))
                {
                    Dictionary<string, int> dataSet;
                    if (cache.ContainsKey(input))
                    {
                        dataSet = cache[input];
                        cache.Remove(input);
                    }
                    else
                        dataSet = new Dictionary<string, int>();
                    data.Add(input, dataSet);
                }
            }
            if (data.Count == 0) return;
            string dataSetKey = string.Empty;
            long maxSize = -1;
            foreach (var dataSet in data)
            {
                long size = dataSet.Value.Sum(dataKey => (long)dataKey.Value);
                if (size <= maxSize) continue;
                maxSize = size;
                dataSetKey = dataSet.Key;
            }
            var set = data[dataSetKey];
            Console.WriteLine($"Data Set: {dataSetKey}, Total Size: {maxSize}");
            foreach (var key in set.Keys)
                Console.WriteLine($"$.{key}");
        }
    }
}

namespace TrafficLights
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            TrafficLight[] trafficLights = Console.ReadLine().Split()
                .Select(s => new TrafficLight(Enum.Parse<Color>(s)))
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.ChangeColor();
                }

                Console.WriteLine(string.Join(" ",trafficLights.Select(l => l.ToString())));
            }
        }
    }
}

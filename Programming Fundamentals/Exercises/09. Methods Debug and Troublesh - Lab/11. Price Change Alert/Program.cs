using System;

namespace _11.Price_Change_Alert
{
    internal class PriceChangeAlert
    {
        private static void Main()
        {
            int numberOfPrices = int.Parse(Console.ReadLine());
            double significanceThreshold = double.Parse(Console.ReadLine());
            double lastPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPrices - 1; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());
                double percentDifference = GetPercentage(lastPrice, currentPrice);
                bool isSignificantDifference = IsSignificant(percentDifference, significanceThreshold);
                string message = GetMessage(currentPrice, lastPrice, percentDifference, isSignificantDifference);
                Console.WriteLine(message);

                lastPrice = currentPrice;
            }
        }

        private static string GetMessage(double currentPrice, double lastPrice, double percentDifference, bool isSignificantDifference)
        {
            string message = "";
            if (percentDifference == 0)
            {
                message = $"NO CHANGE: {currentPrice}";
            }
            else if (!isSignificantDifference)
            {
                message = $"MINOR CHANGE: {lastPrice} to {currentPrice} ({percentDifference:F2}%)";
            }
            else if (percentDifference > 0)
            {
                message = $"PRICE UP: {lastPrice} to {currentPrice} ({percentDifference:F2}%)";
            }
            else if (percentDifference < 0)
                message = $"PRICE DOWN: {lastPrice} to {currentPrice} ({percentDifference:F2}%)";
            return message;
        }

        private static bool IsSignificant(double difference, double threshold)
        {
            return Math.Abs(difference) >= threshold * 100;
        }

        private static double GetPercentage(double lastPrice, double currentPrice)
        {
            return 100 * (currentPrice - lastPrice) / lastPrice;
        }
    }
}
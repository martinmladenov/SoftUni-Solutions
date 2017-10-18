namespace _02.Advertisement_Message
{
    using System;

    public class AdvertisementMessage
    {
        public static void Main()
        {
            var phrases = new[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            var events = new[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            var authors = new[]
            {
                "Diana", "Petya", "Stella", "Elena",
                "Katya", "Iva", "Annie", "Eva"
            };
            var cities = new[]
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };
            var rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[rnd.Next(phrases.Length)]} {events[rnd.Next(events.Length)]} {authors[rnd.Next(authors.Length)]} – {cities[rnd.Next(cities.Length)]}.");
            }
        }
    }
}

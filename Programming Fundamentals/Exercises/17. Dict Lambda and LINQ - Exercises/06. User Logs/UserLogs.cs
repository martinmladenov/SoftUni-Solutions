namespace _06.User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class UserLogs
    {
        public static void Main()
        {
            var messageCount = new SortedDictionary<string, Dictionary<string, int>>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var split = input.Split();
                string ip = split[0].Substring(3);
                string user = split[2].Substring(5);
                if (!messageCount.ContainsKey(user))
                    messageCount[user] = new Dictionary<string, int>();
                if (messageCount[user].ContainsKey(ip))
                    messageCount[user][ip]++;
                else
                    messageCount[user][ip] = 1;
            }
            foreach (var requests in messageCount)
            {
                Console.WriteLine($"{requests.Key}:");
                Console.WriteLine(string.Join(", ",
                    requests.Value
                    .Select(request =>
                    $"{request.Key} => {request.Value}")
                    )
                    + ".");
            }
        }
    }
}

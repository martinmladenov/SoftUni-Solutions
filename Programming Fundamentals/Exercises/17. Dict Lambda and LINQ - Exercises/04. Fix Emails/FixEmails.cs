namespace _04.Fix_Emails
{
    using System;
    using System.Collections.Generic;

    public static class FixEmails
    {
        public static void Main()
        {
            var emails = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                string name = input;
                string email = Console.ReadLine();
                if (email.ToLower().EndsWith("us") ||
                    email.ToLower().EndsWith("uk"))
                    continue;
                emails[name] = email;
            }
            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}

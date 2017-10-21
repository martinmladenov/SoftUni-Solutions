namespace _6.Fix_Emails
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class FixEmails
    {
        public static void Main()
        {
            var emails = new Dictionary<string, string>();
            var input = File.ReadAllLines("input.txt");
            for (var i = 0; i < input.Length; i += 2)
            {
                var name = input[i];
                if (name == "stop")
                    break;
                string email = input[i + 1];
                if (email.ToLower().EndsWith("us") ||
                    email.ToLower().EndsWith("uk"))
                    continue;
                emails[name] = email;
            }
            var output = emails
                .Select(email => $"{email.Key} -> {email.Value}")
                .ToList();
            File.WriteAllLines("output.txt", output);
        }
    }
}

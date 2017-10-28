namespace _07.Query_Mess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class QueryMess
    {
        public static void Main()
        {
            var rgx = new Regex(@"[?&]?(?<field>[^?=]+)=(?<value>[^&]+)");
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var fields = new Dictionary<string, List<string>>();
                foreach (Match match in rgx.Matches(input))
                {
                    string field = FixSpaces(match.Groups["field"].Value);
                    string value = FixSpaces(match.Groups["value"].Value);
                    if (!fields.ContainsKey(field))
                        fields.Add(field, new List<string>());
                    fields[field].Add(value);
                }
                foreach (var field in fields)
                {
                    Console.Write($"{field.Key}=[{string.Join(", ", field.Value)}]");
                }
                Console.WriteLine();
            }
        }

        private static string FixSpaces(string str)
        {
            str = str.Replace("+", " ").Replace("%20", " ");
            char lastChar = '\0';
            string newStr = string.Empty;
            foreach (var c in str)
            {
                if (lastChar != ' ' || c != ' ')
                    newStr += c;
                lastChar = c;
            }
            return newStr.Trim();
        }
    }
}

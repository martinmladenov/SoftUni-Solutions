namespace CustomClassAttribute
{
    using System;
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            CustomClassAttribute attribute = (CustomClassAttribute)typeof(Weapon).GetCustomAttribute(typeof(CustomClassAttribute));

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }
            }
        }
    }
}

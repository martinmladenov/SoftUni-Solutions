namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            object blackBoxInteger = Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var split = input.Split('_');
                string method = split[0];
                object value = int.Parse(split[1]);

                type.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(blackBoxInteger, new[] { value });

                Console.WriteLine(type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(blackBoxInteger));
            }
        }
    }
}

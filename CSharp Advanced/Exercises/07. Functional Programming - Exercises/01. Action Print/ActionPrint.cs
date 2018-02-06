namespace _01._Action_Print
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            Action<string> printAction = Console.WriteLine;
            string[] names = Console.ReadLine().Split();
            foreach (var name in names)
            {
                printAction(name);
            }
        }
    }
}

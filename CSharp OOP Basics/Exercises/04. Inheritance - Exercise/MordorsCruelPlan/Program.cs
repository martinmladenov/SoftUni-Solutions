namespace MordorsCruelPlan
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] foods = Console.ReadLine().Split(' ');

            Gandalf gandalf = new Gandalf();

            foreach (var food in foods)
            {
                gandalf.Eat(food);
            }

            Console.WriteLine(gandalf.HappinessPoints);
            Console.WriteLine(gandalf.Mood.Name);
        }
    }
}

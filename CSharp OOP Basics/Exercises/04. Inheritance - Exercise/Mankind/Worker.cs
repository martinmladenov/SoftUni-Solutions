namespace Mankind
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workingHours;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkingHours = workingHours;
        }

        public decimal WeekSalary
        {
            get => weekSalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                weekSalary = value;
            }
        }

        public decimal WorkingHours
        {
            get => workingHours;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                workingHours = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}" +
                   $"Week Salary: {WeekSalary:f2}{Environment.NewLine}" +
                   $"Hours per day: {WorkingHours:f2}{Environment.NewLine}" +
                   $"Salary per hour: {WeekSalary / 5 / WorkingHours:f2}";
        }
    }
}

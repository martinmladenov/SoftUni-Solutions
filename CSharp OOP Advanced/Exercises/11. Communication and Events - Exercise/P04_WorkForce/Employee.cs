namespace P04_WorkForce
{
    public abstract class Employee
    {
        protected Employee(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract int WorkHoursPerWeek { get; }
    }
}

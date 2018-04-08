namespace P04_WorkForce
{
    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name) : base(name)
        {
        }

        public override int WorkHoursPerWeek => 20;
    }
}

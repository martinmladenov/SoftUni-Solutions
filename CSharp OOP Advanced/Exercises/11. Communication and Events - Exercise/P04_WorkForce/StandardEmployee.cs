namespace P04_WorkForce
{
    public class StandardEmployee : Employee
    {
        public StandardEmployee(string name) : base(name)
        {
        }

        public override int WorkHoursPerWeek => 40;
    }
}

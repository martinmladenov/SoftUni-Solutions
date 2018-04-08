namespace P04_WorkForce
{
    using System;

    public class Job
    {
        public event EventHandler JobFinished;

        private Employee employee;

        public Job(string name, int hoursRemaining, Employee employee)
        {
            this.employee = employee;
            this.Name = name;
            this.HoursRemaining = hoursRemaining;
        }

        public string Name { get; }

        public int HoursRemaining { get; private set; }

        public void Update()
        {
            HoursRemaining -= employee.WorkHoursPerWeek;

            if (HoursRemaining <= 0)
            {
                Console.WriteLine($"Job {Name} done!");
                JobFinished(this, new EventArgs());
            }
        }
    }
}

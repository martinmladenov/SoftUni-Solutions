namespace Employees.Dtos
{
    public class EmployeeOlderThanDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }
        
        public EmployeeDto Manager { get; set; }
    }
}

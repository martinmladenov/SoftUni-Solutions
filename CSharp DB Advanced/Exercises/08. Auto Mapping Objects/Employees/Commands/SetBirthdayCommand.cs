namespace Employees.Commands
{
    using System;
    using System.Globalization;
    using Data;
    using Data.Models;

    public class SetBirthdayCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int employeeId = int.Parse(args[0]);

            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                return $"No employee with ID {employeeId} found";
            }

            employee.Birthday = date;

            context.SaveChanges();

            return $"Birthday of employee {employee.FirstName} {employee.LastName} updated successfully";
        }
    }   
}

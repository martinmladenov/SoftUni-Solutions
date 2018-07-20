namespace Employees.Commands
{
    using Data;
    using Data.Models;

    public class SetManagerCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int employeeId = int.Parse(args[0]);

            int managerId = int.Parse(args[1]);

            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                return $"No employee with ID {employeeId} found";
            }

            Employee manager = context.Employees.Find(managerId);

            if (manager == null)
            {
                return $"No manager with ID {managerId} found";
            }

            employee.Manager = manager;

            context.SaveChanges();

            return
                $"{manager.FirstName} {manager.LastName} successfully set to manage {employee.FirstName} {employee.LastName}";
        }
    }
}

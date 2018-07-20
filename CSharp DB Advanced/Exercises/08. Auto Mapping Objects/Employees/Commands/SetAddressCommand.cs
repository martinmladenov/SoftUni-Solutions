namespace Employees.Commands
{
    using System.Linq;
    using Data;
    using Data.Models;

    public class SetAddressCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int employeeId = int.Parse(args[0]);

            string address = string.Join(' ', args.Skip(1));

            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                return $"No employee with ID {employeeId} found";
            }

            employee.Address = address;

            context.SaveChanges();

            return $"Address of employee {employee.FirstName} {employee.LastName} updated successfully";
        }
    }
}

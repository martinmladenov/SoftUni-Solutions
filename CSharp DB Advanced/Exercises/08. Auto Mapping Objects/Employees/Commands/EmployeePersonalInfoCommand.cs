namespace Employees.Commands
{
    using System.Globalization;
    using System.Text;
    using Data;
    using Data.Models;

    public class EmployeePersonalInfoCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int employeeId = int.Parse(args[0]);

            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                return $"No employee with ID {employeeId} found";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeId} - {employee.FirstName} {employee.LastName} - ${employee.Salary}");

            string birthday =
                employee.Birthday?.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                ?? "N/A";

            sb.AppendLine($"Birthday: {birthday}");

            string address = employee.Address ?? "N/A";

            sb.AppendLine($"Address: {address}");

            return sb.ToString();
        }
    }
}

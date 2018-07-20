using Employees.Data;

namespace Employees.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using AutoMapper.QueryableExtensions;
    using Dtos;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int age = int.Parse(args[0]);

            var employees = context.Employees
                .Where(e => e.Birthday.HasValue && e.Birthday.Value.AddYears(age) <= DateTime.Now)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeOlderThanDto>()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var manager = employee.Manager;
                var managerStr = manager == null ? "[no manager]" : $"{manager.FirstName} {manager.LastName}";
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary} - Manager: {managerStr}");
            }

            return sb.ToString();
        }
    }
}

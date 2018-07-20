namespace Employees.Commands
{
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Dtos;
    using Microsoft.EntityFrameworkCore;

    public class ManagerInfoCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int managerId = int.Parse(args[0]);

            Employee manager = context.Employees
                .Include(e => e.ManagedEmployees)
                .FirstOrDefault(e => e.Id == managerId);

            if (manager == null)
            {
                return $"No manager with ID {managerId} found";
            }

            ManagerDto managerDto = Mapper.Map<ManagerDto>(manager);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
                $"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.ManagedEmployeesCount}");

            foreach (var employeeDto in managerDto.ManagedEmployees)
            {
                sb.AppendLine($"  - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary}");
            }

            return sb.ToString();
        }
    }
}

namespace Employees.Commands
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Dtos;

    public class EmployeeInfoCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            int employeeId = int.Parse(args[0]);

            Employee employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                return $"No employee with ID {employeeId} found";
            }

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return $"ID: {employeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary}";
        }
    }
}

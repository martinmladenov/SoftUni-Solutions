namespace Employees.Commands
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Dtos;

    public class AddEmployeeCommand : ICommand
    {
        public string Execute(EmployeesDbContext context, string[] args)
        {
            EmployeeDto employeeDto = new EmployeeDto
            {
                FirstName = args[0],
                LastName = args[1],
                Salary = decimal.Parse(args[2])
            };

            var employee = Mapper.Map<Employee>(employeeDto);

            context.Employees.Add(employee);
            context.SaveChanges();

            return "Employee successfully added";
        }
    }
}

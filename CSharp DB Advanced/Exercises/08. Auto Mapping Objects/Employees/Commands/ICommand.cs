namespace Employees.Commands
{
    using Data;

    public interface ICommand
    {
        string Execute(EmployeesDbContext context, string[] args);
    }
}

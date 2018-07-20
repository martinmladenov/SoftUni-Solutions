namespace Employees.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class EmployeesDbContext : DbContext
    {
        private const string ConnectionString = 
            @"Server=.\SQLEXPRESS;Database=Employees;Integrated Security=True";

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}

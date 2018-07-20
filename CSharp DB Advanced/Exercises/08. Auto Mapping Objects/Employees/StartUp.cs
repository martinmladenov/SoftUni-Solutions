namespace Employees
{
    using AutoMapper;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<EmployeesProfile>());

            using (var context = new EmployeesDbContext())
            {
                context.Database.Migrate();

                var engine = new Engine(context);

                engine.StartInterpretingCommands();
            }
        }
    }
}

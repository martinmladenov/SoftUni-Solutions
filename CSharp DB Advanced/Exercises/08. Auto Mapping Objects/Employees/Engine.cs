namespace Employees
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Data;

    public class Engine
    {
        private EmployeesDbContext context;

        public Engine(EmployeesDbContext context)
        {
            this.context = context;
        }

        public void StartInterpretingCommands()
        {
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine().Trim();

                if (input == "Exit")
                {
                    break;
                }

                var split = input.Split();

                var commandClassName = split[0] + "Command";

                var args = split.Skip(1).ToArray();

                Type commandType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == commandClassName);

                if (commandType == null)
                {
                    Console.WriteLine("Invalid command");
                    continue;
                }

                ICommand cmd = (ICommand)Activator.CreateInstance(commandType);

                var result = cmd.Execute(this.context, args);

                Console.WriteLine(result.Trim());
            }
        }
    }
}

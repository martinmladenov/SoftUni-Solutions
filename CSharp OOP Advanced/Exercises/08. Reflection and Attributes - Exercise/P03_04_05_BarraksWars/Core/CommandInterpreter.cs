namespace BarracksWars.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public string InterpretCommand(string[] data, string commandName)
        {
            if (commandName == "fight")
            {
                Environment.Exit(0);
                return null;
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(
                Type.GetType("BarracksWars.Core.Commands."
                             + char.ToUpper(commandName[0]) + commandName.Substring(1) + "Command"),
                new object[] { data });


            foreach (var field in command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(field => field.GetCustomAttribute(typeof(InjectAttribute)) != null))
            {
                field.SetValue(command,
                    this.GetType()
                    .GetField(field.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this));
            }

            return command.Execute();
        }
    }
}
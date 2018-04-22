namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string typeName)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == typeName);

            return (ISet)Activator.CreateInstance(type, name);
        }
    }
}

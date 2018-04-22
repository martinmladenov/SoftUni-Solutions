namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string typeName)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == typeName);

            return (IInstrument) Activator.CreateInstance(type);
        }
    }
}
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "END")
            {
                try
                {
                    var result = ProcessCommand(input);
                    writer.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            writer.WriteLine("Results:");
            writer.WriteLine(festivalCоntroller.ProduceReport());
        }

        public string ProcessCommand(string input)
        {
            var split = input.Split();

            var firstArg = split.First();
            var parameters = split.Skip(1).ToArray();

            if (firstArg == "LetsRock")
            {
                var sets = setCоntroller.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == firstArg);

            return (string)festivalcontrolfunction.Invoke(festivalCоntroller, new object[] { parameters });
        }
    }
}
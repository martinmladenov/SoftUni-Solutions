namespace BarracksWars.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.data = data;
        }

        protected string[] Data
        {
            get => data;
            private set => data = value;
        }

        public abstract string Execute();
    }
}

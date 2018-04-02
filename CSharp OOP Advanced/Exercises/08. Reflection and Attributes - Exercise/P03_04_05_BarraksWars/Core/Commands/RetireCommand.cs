namespace BarracksWars.Core.Commands
{
    using System;
    using Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            try
            {
                this.repository.RemoveUnit(unitType);
                return unitType + " retired!";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}

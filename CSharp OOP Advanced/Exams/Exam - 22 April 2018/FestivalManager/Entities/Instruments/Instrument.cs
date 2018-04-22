namespace FestivalManager.Entities.Instruments
{
    using System;
    using Contracts;

    public abstract class Instrument : IInstrument
    {
        private double wear;

        private const int MaxWear = 100;
        private const int MinWear = 0;

        protected Instrument()
        {
            this.Wear = MaxWear;
        }

        public double Wear
        {
            get => this.wear;
            private set => this.wear = Math.Min(Math.Max(value, MinWear), MaxWear);
        }

        public bool IsBroken => this.Wear <= MinWear;

        protected abstract int RepairAmount { get; }

        public void Repair() => this.Wear += this.RepairAmount;

        public void WearDown() => this.Wear -= this.RepairAmount;

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : string.Format("{0}%", this.Wear);

            return string.Format("{0} [{1}]", this.GetType().Name, instrumentStatus);
        }
    }
}

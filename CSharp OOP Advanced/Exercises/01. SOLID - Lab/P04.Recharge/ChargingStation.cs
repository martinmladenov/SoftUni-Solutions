using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class ChargingStation
    {
        private IRechargeable rechargeable;

        public ChargingStation(IRechargeable rechargeable)
        {
            this.rechargeable = rechargeable;
        }

        public void Recharge()
        {
            rechargeable.Recharge();
        }
    }
}

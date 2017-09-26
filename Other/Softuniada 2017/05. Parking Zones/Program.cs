using System;
using System.Collections.Generic;

namespace _05.Parking_Zones
{
    class Program
    {
        static void Main(string[] args)
        {
            var zones = new List<ParkingZone>();
            var freeParkingSpaces = new List<ZonedParkingSpace>();

            var zonesToReceive = int.Parse(Console.ReadLine());
            for (var i = 0; i < zonesToReceive; i++)
            {
                var split = Console.ReadLine().Split(": ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var color = split[0];
                var x = int.Parse(split[1]);
                var y = int.Parse(split[2]);
                var width = int.Parse(split[3]);
                var height = int.Parse(split[4]);
                var price = double.Parse(split[5]);
                var zone = new ParkingZone(color, x, y, width, height, price);

                zones.Add(zone);
            }

            var splitSpaces = Console.ReadLine().Split(", ;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < splitSpaces.Length; i += 2)
            {
                var x = int.Parse(splitSpaces[i]);
                var y = int.Parse(splitSpaces[i + 1]);
                var unzonedSpace = new ParkingSpace(x, y);
                foreach (var zone in zones)
                    if (zone.IsInside(unzonedSpace))
                    {
//                        Console.WriteLine($"{unzonedSpace.X} {unzonedSpace.Y} is inside {zone.Color}");
                        freeParkingSpaces.Add(zone.GetParkingSpace(unzonedSpace));
                    }
            }

            var pointSplit = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var store = new TargetPoint(int.Parse(pointSplit[0]), int.Parse(pointSplit[1]));


            var k = int.Parse(Console.ReadLine());

            var lowestPrice = double.MaxValue;
            ZonedParkingSpace lowestPriceSpace = null;

            foreach (var space in freeParkingSpaces)
            {
                var priceToStore = space.GetPriceToPointAndBack(store, k);
//                Console.WriteLine($"{space.X} {space.Y} zone: {space.Zone.Color} dist: {store.GetDistance(space)} price: {priceToStore}");
                if (priceToStore < lowestPrice)
                {
                    lowestPrice = priceToStore;
                    lowestPriceSpace = space;
                }
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                else if (lowestPrice == priceToStore && space.GetTimeInSeconds(store, k) <
                         lowestPriceSpace.GetTimeInSeconds(store, k))
                {
                    lowestPrice = priceToStore;
                    lowestPriceSpace = space;
                }
            }


            Console.WriteLine("Zone Type: {0}; X: {1}; Y: {2}; Price: {3:f2}", lowestPriceSpace.Zone.Color, lowestPriceSpace.X, lowestPriceSpace.Y, lowestPrice);
//            Main(args);
        }
    }

    class ParkingZone
    {
        public string Color { get; }
        public int X { get; }
        public int Y { get; }
        public int EndX { get; }
        public int EndY { get; }
        public double PricePerMinute { get; }
        public ParkingZone(string color, int x, int y, int width, int height, double pricePerMinute)
        {
            Color = color;
            X = x;
            Y = y;
            EndX = x + width;
            EndY = y + height;
            PricePerMinute = pricePerMinute;
        }

        public bool IsInside(ParkingSpace space)
        {
            return space.X >= X && space.X < EndX && space.Y >= Y && space.Y < EndY;
        }

        public ZonedParkingSpace GetParkingSpace(ParkingSpace space)
        {
            return new ZonedParkingSpace(space.X, space.Y, this);
        }
    }

    class ParkingSpace
    {
        public int X { get; }
        public int Y { get; }

        public ParkingSpace(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double GetTimeInSeconds(TargetPoint point, int k)
        {
            return k * point.GetDistance(this);
        }
    }

    class ZonedParkingSpace : ParkingSpace
    {
        public ParkingZone Zone { get; }
        public ZonedParkingSpace(int x, int y, ParkingZone z) : base(x, y)
        {
            Zone = z;
        }

        public double GetPriceToPointAndBack(TargetPoint point, int k)
        {
            return Math.Ceiling(GetTimeInSeconds(point, k) * 2 / 60d) * Zone.PricePerMinute;
        }

    }

    class TargetPoint : ParkingSpace
    {
        public TargetPoint(int x, int y) : base(x, y) { }

        public int GetDistance(ParkingSpace space)
        {
            return Math.Abs(X - space.X) + Math.Abs(Y - space.Y) - 1;
        }

    }
}

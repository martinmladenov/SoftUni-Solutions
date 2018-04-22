namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private readonly IStage stage;

        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;

            instrumentFactory = new InstrumentFactory();
            performerFactory = new PerformerFactory();
            setFactory = new SetFactory();
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += $"Festival length: {FormatTime(totalFestivalLength)}" + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += $"--{set.Name} ({FormatTime(set.ActualDuration)}):" + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += $"---{performer.Name} ({instruments})" + Environment.NewLine;
                }

                if (!set.Songs.Any())
                    result += "--No songs played" + Environment.NewLine;
                else
                {
                    result += "--Songs played:" + Environment.NewLine;
                    foreach (var song in set.Songs)
                    {
                        result += $"----{song.Name} ({FormatTime(song.Duration)})" + Environment.NewLine;
                    }
                }
            }

            return result;
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            int mins = timeSpan.Days * 1440 + timeSpan.Hours * 60 + timeSpan.Minutes;
            int secs = timeSpan.Seconds;

            return $"{mins:d2}:{secs:d2}";
        }

        public string RegisterSet(string[] args)
        {
            ISet set = setFactory.CreateSet(args[0], args[1]);

            stage.AddSet(set);

            return $"Registered {args[1]} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instruments = args.Skip(2)
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];
            string[] durationStr = args[1].Split(':');

            int minutes = int.Parse(durationStr[0]);
            int seconds = int.Parse(durationStr[1]);

            TimeSpan duration = new TimeSpan(0, minutes, seconds);

            stage.AddSong(new Song(songName, duration));

            return $"Registered song {songName} ({duration:mm\\:ss})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }


        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}
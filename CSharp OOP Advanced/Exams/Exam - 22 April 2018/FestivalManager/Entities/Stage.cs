namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            sets = new List<ISet>();
            songs = new List<ISong>();
            performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => sets;
        public IReadOnlyCollection<ISong> Songs => songs;
        public IReadOnlyCollection<IPerformer> Performers => performers;

        public IPerformer GetPerformer(string name)
        {
            return performers.First(p => p.Name == name);
        }

        public ISong GetSong(string name)
        {
            return songs.First(s => s.Name == name);
        }

        public ISet GetSet(string name)
        {
            return sets.First(s => s.Name == name);
        }

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            songs.Add(song);
        }

        public void AddSet(ISet set)
        {
            sets.Add(set);
        }

        public bool HasPerformer(string name)
        {
            return performers.Any(p => p.Name == name);
        }

        public bool HasSong(string name)
        {
            return songs.Any(s => s.Name == name);
        }

        public bool HasSet(string name)
        {
            return sets.Any(s => s.Name == name);
        }
    }
}

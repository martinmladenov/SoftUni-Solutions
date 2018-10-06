namespace SIS.IRunesApp.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Album
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price => this.Tracks.Sum(t => t.Price) * 0.87m;

        public ICollection<Track> Tracks { get; set; }
    }
}
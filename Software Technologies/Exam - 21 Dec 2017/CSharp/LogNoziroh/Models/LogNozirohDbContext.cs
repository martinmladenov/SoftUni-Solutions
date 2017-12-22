using System.Data.Entity;

namespace LogNoziroh.Models
{
    public class LogNozirohDbContext : DbContext
    {
        public virtual IDbSet<Report> Reports { get; set; }

        public LogNozirohDbContext() : base("LogNoziroh")
        {
        }
    }
}
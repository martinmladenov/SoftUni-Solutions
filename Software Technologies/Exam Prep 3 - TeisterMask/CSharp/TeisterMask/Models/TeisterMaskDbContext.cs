using System.Data.Entity;

namespace TeisterMask.Models
{
    public class TeisterMaskDbContext : DbContext
    {
        public virtual IDbSet<Task> Tasks { get; set; }

        public TeisterMaskDbContext() : base("TeisterMask")
        {
        }
    }
}

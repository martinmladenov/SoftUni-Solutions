namespace _2.TODOList.Models
{
    using System.Data.Entity;

    public class TaskDbContext : DbContext
    {
        public TaskDbContext()
            : base("name=TaskDbContext")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
    }
}

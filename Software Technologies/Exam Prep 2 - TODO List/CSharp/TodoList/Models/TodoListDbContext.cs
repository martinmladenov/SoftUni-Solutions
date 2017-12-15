using System.Data.Entity;

namespace TodoList.Models
{
    public class TodoListDbContext : DbContext
    {
        public virtual IDbSet<Task> Tasks { get; set; }

        public TodoListDbContext() : base("TodoListDb")
        {
        }
    }
}

using System.Data.Entity;

namespace ShoppingList.Models
{
    public class ShoppingListDbContext : DbContext
    {
        public virtual IDbSet<Product> Products { get; set; }

        public ShoppingListDbContext() : base("ShoppingList")
        {
        }
    }
}

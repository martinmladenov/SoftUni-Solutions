namespace P03_SalesDatabase
{
    using Data;

    public class Program
    {
        public static void Main()
        {
            using (SalesContext context = new SalesContext())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}

namespace P01_StudentSystem
{
    using Data;

    public class Program
    {
        public static void Main()
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}

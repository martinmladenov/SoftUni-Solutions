namespace P03_FootballBetting
{
    using Data;

    public class Program
    {
        public static void Main()
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}

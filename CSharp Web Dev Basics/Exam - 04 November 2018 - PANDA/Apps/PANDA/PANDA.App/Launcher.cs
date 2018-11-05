namespace PANDA.App
{
    using System;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using SIS.Framework;

    public class Launcher
    {
        public static void Main()
        {
            using (var context = new PandaDbContext())
            {
                Console.WriteLine("Migrating database...");
                context.Database.Migrate();
                Console.WriteLine("Migration successful.");
            }

            WebHost.Start(new StartUp());
        }
    }
}

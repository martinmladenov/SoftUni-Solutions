namespace Eventures.Web.Middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Eventures.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class SeedMiddleware
    {
        private readonly RequestDelegate next;

        private bool executed;

        public SeedMiddleware(RequestDelegate next)
        {
            this.next = next;

            this.executed = false;
        }

        public async Task InvokeAsync(HttpContext httpContext,
            EventuresDbContext dbContext,
            UserManager<EventuresUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!this.executed)
            {
                this.executed = true;

                dbContext.Database.EnsureCreated();

                if (!await roleManager.RoleExistsAsync(GlobalConstants.AdminRoleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRoleName));
                }

                if (await dbContext.Events.CountAsync() < 35)
                {
                    var currTime = DateTime.Now;

                    var random = new Random();


                    var events = new EventuresEvent[35];

                    for (int i = 0; i < 35; i++)
                    {
                        var startDate = currTime.AddDays(random.NextDouble() * 300 - 150);
                        var endDate = startDate.AddDays(random.NextDouble() * 15 + 5);

                        events[i] = new EventuresEvent
                        {
                            Name = "Seeded Event " + (i + 1),
                            Place = "Seeded Place " + (i % 10 + 1),
                            StartDate = startDate,
                            EndDate = endDate,
                            TotalTickets = random.Next(5, 500),
                            PricePerTicket = (decimal) random.NextDouble() * 150 + 50,
                        };
                    }

                    await dbContext.Events.AddRangeAsync(events);

                    await dbContext.SaveChangesAsync();
                }

                if (!userManager.Users.Any(u => u.UserName == "admin"))
                {
                    var user = new EventuresUser
                    {
                        UserName = "admin",
                        Email = "admin@example.com",
                        FirstName = "admin",
                        LastName = "admin",
                        UniqueCitizenNumber = "0000000000"
                    };

                    await userManager.CreateAsync(user, "admin");

                    await userManager.AddToRoleAsync(user, GlobalConstants.AdminRoleName);
                }
            }

            await this.next(httpContext);
        }
    }
}
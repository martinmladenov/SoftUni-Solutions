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
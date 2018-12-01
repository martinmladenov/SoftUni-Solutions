namespace Eventures.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Eventures.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly UserManager<EventuresUser> userManager;

        public UsersController(UserManager<EventuresUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = this.userManager.Users
                .ProjectTo<UserListingViewModel>()
                .ToArray();

            var adminIds = (await this.userManager
                    .GetUsersInRoleAsync(GlobalConstants.AdminRoleName))
                .Select(r => r.Id)
                .ToHashSet();

            foreach (var user in users)
            {
                user.IsAdmin = adminIds.Contains(user.Id);
            }

            var orderedUsers = users
                .OrderByDescending(u => u.IsAdmin)
                .ThenBy(u => u.UserName);

            return this.View(orderedUsers);
        }

        [HttpPost]
        public async Task<IActionResult> Promote(string userId)
        {
            if (userId == null)
            {
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null || await this.userManager.IsInRoleAsync(user, GlobalConstants.AdminRoleName))
            {
                return this.RedirectToAction("Index");
            }

            await this.userManager.AddToRoleAsync(user, GlobalConstants.AdminRoleName);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Demote(string userId)
        {
            if (userId == null)
            {
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null || !await this.userManager.IsInRoleAsync(user, GlobalConstants.AdminRoleName))
            {
                return this.RedirectToAction("Index");
            }

            await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.AdminRoleName);

            return this.RedirectToAction("Index");
        }
    }
}
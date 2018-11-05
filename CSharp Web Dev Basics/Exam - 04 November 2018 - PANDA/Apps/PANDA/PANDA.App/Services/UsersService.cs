namespace PANDA.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using PANDA.Models;

    public class UsersService : DataService, IUsersService
    {
        private IHashService hashService;

        public UsersService(PandaDbContext context, IHashService hashService) : base(context)
        {
            this.hashService = hashService;
        }

        public User Create(string username, string password, string email)
        {
            if (this.context.Users.Any(u => u.Username == username))
            {
                return null;
            }

            var salt = this.hashService.GenerateSalt();

            var hash = this.hashService.HashPassword(password, salt);

            User user = new User
            {
                Username = username,
                Password = hash,
                Email = email,
                Role = this.context.Users.Any() ? Role.User : Role.Admin
            };

            this.context.Users.Add(user);

            this.context.SaveChanges();

            return user;
        }

        public User Get(string username, string password)
        {
            var user = this.context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                return null;
            }

            var hashedPassword = user.Password;

            if (!this.hashService.IsPasswordValid(password, hashedPassword))
            {
                return null;
            }

            return user;
        }

        public ICollection<UserSelectViewModel> GetAll()
        {
            var users = this.context.Users.ToArray();

            var userModels = users.Select(u => new UserSelectViewModel
            {
                Id = u.Id,
                Username = u.Username
            })
            .ToArray();

            return userModels;
        }
    }
}
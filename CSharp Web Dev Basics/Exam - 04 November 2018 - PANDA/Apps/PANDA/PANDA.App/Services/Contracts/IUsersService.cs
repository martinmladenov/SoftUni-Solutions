namespace PANDA.App.Services.Contracts
{
    using System.Collections.Generic;
    using Models;
    using PANDA.Models;

    public interface IUsersService
    {
        User Create(string username, string password, string email);
        User Get(string username, string password);

        ICollection<UserSelectViewModel> GetAll();
    }
}
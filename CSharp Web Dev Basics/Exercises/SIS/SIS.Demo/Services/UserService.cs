namespace SIS.Demo.Services
{
    using Contracts;

    public class UserService : IUserService
    {
        public bool VerifyPassword(string username, string password)
        {
            // Password verification logic is unnecessary for now
            return username.Length > 0 && password.Length > 0;
        }
    }
}
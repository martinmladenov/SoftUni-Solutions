namespace SIS.Demo.Services.Contracts
{
    public interface IUserService
    {
        bool VerifyPassword(string username, string password);
    }
}
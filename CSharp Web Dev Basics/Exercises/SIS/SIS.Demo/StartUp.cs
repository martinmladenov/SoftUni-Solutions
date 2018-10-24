namespace SIS.Demo
{
    using Framework.Api;
    using Framework.Services;
    using Services;
    using Services.Contracts;

    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUserService, UserService>();
        }
    }
}
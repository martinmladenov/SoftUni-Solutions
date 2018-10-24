namespace SIS.Framework.Api
{
    using Services;

    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IDependencyContainer dependencyContainer);
    }
}
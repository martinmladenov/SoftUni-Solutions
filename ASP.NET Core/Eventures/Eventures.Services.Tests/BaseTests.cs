namespace Eventures.Services.Tests
{
    using Infrastructure.Mapping;

    public abstract class BaseTests
    {
        protected BaseTests()
        {
            AutoMapperConfig.ConfigureMapping();
        }
    }
}
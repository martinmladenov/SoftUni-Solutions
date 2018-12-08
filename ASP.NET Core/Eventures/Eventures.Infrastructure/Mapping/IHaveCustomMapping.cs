namespace Eventures.Infrastructure.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(IMapperConfigurationExpression mapper);
    }
}

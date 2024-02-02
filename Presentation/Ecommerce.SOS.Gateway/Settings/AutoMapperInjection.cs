using AutoMapper;
using Ecommerce.SOS.Datasources.MongoDB.Mappers;

namespace Ecommerce.SOS.Gateway.Settings
{
    public static class AutoMapperInjection
    {
        public static void ConfigureAutoMapper(IServiceCollection service)
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperDS>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
        }
    }
}


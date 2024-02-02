using Ecommerce.SOS.Application.Contrats.Datasources;
using Ecommerce.SOS.Application.Contrats.UserCases.Collections;
using Ecommerce.SOS.Application.UserCases.Collections;
using Ecommerce.SOS.Datasources.MongoDB.ContextFactory;
using Ecommerce.SOS.Datasources.MongoDB.Implementations;

namespace Ecommerce.SOS.Gateway.Settings
{
    public static class DependenciesInjection
    {
        public static void InjectDependencies(IServiceCollection service)
        {


            //Automapper
            AutoMapperInjection.ConfigureAutoMapper(service);

            //MongoDB
            service.AddSingleton<MongoFactory>();

            //Datasources
            service.AddTransient<ICollectionsDS, CollectionsDS>();

            //User Cases
            service.AddTransient<IGetPagedCollectionsUC, GetPagedCollectionsUC>();
        }
    }
}


using Microsoft.Extensions.DependencyInjection;
using BankStore.DL.Interfaces;
using BankStore.DL.Repositories;
using BankStore.DL.Repositories.MongoDb;

namespace BankStore.DL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection
            RegisterRepositoies(this IServiceCollection services)
        {
            return services
                .AddSingleton<IBankRepository,BankMongoRepository>()
                .AddSingleton<ICustumerRepository,CustumerMongoRepository>();

        }
    }
}
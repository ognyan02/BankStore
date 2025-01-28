using Microsoft.Extensions.DependencyInjection;
using BankStore.BL.Interfaces;
using BankStore.BL.Services;

namespace BankStore.BL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection
            RegisterServices(this IServiceCollection services)
       {
            return services
                         .AddSingleton<IBankservises, BankServises>()
                         .AddSingleton<IBussinesservises, BussinesServises>();   
       }

    }
}
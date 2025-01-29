using Mapster;
using BankStore.Models.DTO;
using BankStore.Models.Requests;
namespace BankStore.MapConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddBankRequests, Bank>
                .NewConfig();
        }
    }
}

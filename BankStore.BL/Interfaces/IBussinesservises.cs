using BankStore.Models.Responses;

namespace BankStore.BL.Interfaces
{
    public interface IBussinesservises
    {
        List<BankfulldetailsResponses> GetAllBank();
    }
}

using BankStore.Models.DTO;

namespace BankStore.DL.Interfaces
{
    public interface ICustumerRepository
    {
        List<Customers> GetAll();
        Customers? GetById(string id);
    }
}

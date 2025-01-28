using BankStore.Models.DTO;

namespace BankStore.DL.Interfaces
{
    public interface ICustumerRepository
    {
        List<Custumers> GetAll();
        Custumers? GetById(string id);
    }
}

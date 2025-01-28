using BankStore.Models.DTO;
namespace BankStore.DL.Interfaces
{
    public interface IBankRepository
    {
        List<Bank> GetAll();
        Bank? GetById(string id);
        void Add(Bank bank);
        void Update(Bank bank);

    }
}

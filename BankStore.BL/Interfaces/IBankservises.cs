using BankStore.Models.DTO;

    namespace BankStore.BL.Interfaces
{
    public interface IBankservises
    {
     List<Bank>GetAll();
        Bank? GetById(string id);
        void Add(Bank bank);
        void AddCustumersToBank(string BankId, string custumers);
       
    }
}



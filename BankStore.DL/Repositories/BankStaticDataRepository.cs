using BankStore.DL.Interfaces;
using BankStore.DL.StaticData;
using BankStore.Models.DTO;


namespace BankStore.DL.Repositories
{   

    internal class BankStaticDataRepository : IBankRepository
    {
        public void Add(Bank bank)
        {
            throw new NotImplementedException();
        }

        public List<Bank>GetAll()
        {
            return StaticData.StaticData.Bank;
        }
        public Bank? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return StaticData.StaticData.Bank.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}



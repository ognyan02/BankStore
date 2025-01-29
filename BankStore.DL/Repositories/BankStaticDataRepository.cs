using System.ComponentModel;
using BankStore.DL.Interfaces;
using BankStore.DL.StaticData;
using BankStore.Models.DTO;

namespace BankStore.DL.Repositories
{   

    internal class BankStaticDataRepository : IBankRepository
    {
        public List<StaticData.Bank>GetAll()
        {
            return StaticData.Bank;
        }
        public StaticData.Bank? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return StaticData.Bank.FirstOrDefault(x => x.Id == id);
        }
    }
}

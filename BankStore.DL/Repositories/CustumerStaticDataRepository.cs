using BankStore.DL.Interfaces;
using BankStore.Models.DTO;

namespace BankStore.DL.Repositories
{
    
    internal class CustumersStaticDataRepository : ICustumerRepository
    {
        public List<Customers> GetAll()
        {
            return StaticData.StaticData.Custumers;
        }

        public Customers? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return StaticData.StaticData.Custumers.FirstOrDefault(x => x.Id == id);
        }
    }
}



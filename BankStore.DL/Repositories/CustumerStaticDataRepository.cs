using BankStore.DL.Interfaces;
using BankStore.DL.StaticData;
using BankStore.Models.DTO;

namespace BankStore.DL.Repositories
{
    
    internal class CustumersStaticDataRepository : ICustumerRepository
    {
        public List<StaticData.Custumers> GetAll()
        {
            return StaticData.Custumers;
        }

        public StaticData.Custumers? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return StaticData.Custumers
               .FirstOrDefault(x => x.Id == id);
        }
    }
}
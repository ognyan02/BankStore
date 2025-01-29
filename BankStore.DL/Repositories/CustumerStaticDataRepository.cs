using BankStore.DL.Interfaces;
using BankStore.DL.StaticData;
using BankStore.Models.DTO;

namespace BankStore.DL.Repositories
{
    
    internal class CustumersStaticDataRepository : ICustumerRepository
    {
        public List<Custumers> GetAll()
        {
            return StaticData.StaticData.Custumers;
        }

        public Custumers? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return StaticData.StaticData.Custumers.FirstOrDefault(x => x.Id == id);
        }
    }
}
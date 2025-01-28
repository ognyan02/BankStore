using BankStore.BL.Interfaces;
using BankStore.DL.Interfaces;
using BankStore.Models.DTO;
using BankStore.Models.Responses;

namespace BankStore.BL.Services
{
    internal class BussinesServises : IBussinesservises
    {
       
        private IBankRepository _bankRepository;
        private ICustumerRepository _custumerRepository;

        public BussinesServises(
            IBankRepository bankRepository,
            ICustumerRepository custumerRepository)
        {
            _bankRepository = bankRepository;
            _custumerRepository = custumerRepository;
        }
        public List<BankfulldetailsResponses> GetAllBank()
        {
            var result = new List<BankfulldetailsResponses>();
            var bank = _bankRepository.GetAll();
            foreach (var Bank in bank)
            {
                var detailedBank = new BankfulldetailsResponses()
                {
                  Id= Bank.Id,
                  Name = Bank.Name,
                  Nomer = Bank.Nomer
                };
                foreach (var custumersId in Bank.Custumers)
                {
                    var custumers = _custumerRepository.GetById(custumersId);
                    if (custumers == null) continue;
                    detailedBank.Custumers.Add(custumers);
                
                }
                result.Add(detailedBank);
            }
            return result;
        }
    }
}
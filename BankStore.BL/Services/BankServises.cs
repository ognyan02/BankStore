using Microsoft.Extensions.Logging;
using BankStore.BL.Interfaces;
using BankStore.DL.Interfaces;
using BankStore.Models.DTO;
using System.Runtime.CompilerServices;

namespace BankStore.BL.Services
{
    public class BankServises : IBankservises
    {
        private readonly IBankRepository _bankRepository;
        private readonly ICustumerRepository _custumerRepository;
        private readonly ILogger<BankServises> _logger;

        public BankServises(IBankRepository object1, ILogger<BankServises> logger, ICustumerRepository object2)
        {
        }

        public void Add(Bank bank)
        {
            if (bank == null)
            {
                _logger.LogError("bank is nul");
                return;
            }
            bank.Id = Guid.NewGuid().ToString();
            _bankRepository.Add(bank);
        }
        public void AddCustumersToBank(string bankId, string custumerId)
        {
            if (string.IsNullOrEmpty(bankId) || string.IsNullOrEmpty(custumerId))
            {
                _logger.LogError("bankId or custumerId is null");
                return;
            }
            if (Guid.TryParse(bankId, out _) || Guid.TryParse(custumerId, out _))
            {
                _logger.LogError("bankId or custumerId is not valid");
                return;
            }
            var bank = _bankRepository.GetById(bankId);
            if (bank == null)
            {
                _logger.LogError("bank not found");
                return;
            }
            var custumer = _custumerRepository.GetById(custumerId);
            if (custumer == null)
            {
                _logger.LogError("custumer not found");
                return;
            }
            if (bank.Customers == null)
            {
                bank.Customers = new List<string>();
            }
            bank.Customers.Add(custumerId);
            _bankRepository.Update(bank);

        }
        public List<Bank> GetAll()
        {
            return _bankRepository.GetAll();
        }
        public Bank? GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _)) return null;

            return _bankRepository.GetById(id);
        }
    }    

}

using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BankStore.DL.Interfaces;
using BankStore.Models.Configurations;
using BankStore.Models.DTO;


namespace BankStore.DL.Repositories.MongoDb
{
    internal class BankMongoRepository : IBankRepository
    {
        private readonly IMongoCollection<Bank> _bankCollection;
        private readonly ILogger<BankMongoRepository> _logger;
        public BankMongoRepository(
            IOptionsMonitor<MongoDBConfiguration> mongoConfig,
            ILogger<BankMongoRepository> logger)
        {

            _logger = logger;

            var client = new MongoClient(mongoConfig.CurrentValue.MongoBanka);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DataBaseName);
            _bankCollection = database.GetCollection<Bank>("Banka1");
        }
        public List<Bank> GetAll()
        {
            return _bankCollection.Find(m => true).ToList();
        }
        public Bank? GetById(string id)
        {
            return _bankCollection.Find(m => m.Id == id).FirstOrDefault();
        }
        public void Add(Bank? bank)
        {
            if (bank == null)
            {
                _logger.LogError("Bank is null");
                return;
            }
            try
            {
                _bankCollection.InsertOne(bank);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add team");
            }
        }
        public void Update(Bank bank)
        {
            _bankCollection.ReplaceOne(m => m.Id == bank.Id, bank);
        }
    }
}
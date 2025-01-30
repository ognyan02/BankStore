using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankStore.DL.Interfaces;
using BankStore.Models.DTO;

namespace BankStore.DL.Repositories.MongoDb
{
    internal class CustumerMongoRepository : ICustumerRepository
    {
        public List<Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customers? GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
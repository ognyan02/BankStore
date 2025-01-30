using BankStore.Models.DTO;

namespace BankStore.DL.StaticData
{
    public static class StaticData
    {
        public static List<Customers> Custumers { get; set; } = new List<Customers>()
        {
         new Customers()
        {
            Id= "1",
            Name = "Ivan Georgiev"
        },
        new Customers()
        {
            Id= "2",
            Name ="Georgi Ivanov"
        },
        new Customers()
        {
            Id = "3",
            Name= "Petur Petrov"
        }

        };
        public static List<Bank> Bank { get; set; } = new List<Bank>()
        {
            new Bank()
            {
                Id = "1",
                Name = "UnicreditBulbank",
                Nomer = 10,
                
            },
            new Bank()
            {
                Id = "2",
                Name = "OBB",
                Nomer = 20,
                
            },
            new Bank()
            {
                Id = "3",
                Name = "DSK",
                Nomer = 33,
                
            }
       
        };
    }
}

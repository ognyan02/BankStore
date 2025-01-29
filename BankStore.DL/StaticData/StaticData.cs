using BankStore.Models.DTO;

namespace BankStore.DL.StaticData
{
    internal static class StaticData
    {
        public static List<Custumers> Custumers { get; set; } = new List<Custumers>()
        {
         new Custumers()
        {
            Id= 1,
            Name = "Ivan Georgiev"
        },
        new Custumers()
        {
            Id= 2,
            Name ="Georgi Ivanov"
        },
        new Custumers()
        {
            Id = 3,
            Name="Petur Petrov"
        }

        };
        public static List<Bank> Banks { get; set; } = new List<Bank>()
        {
            new Bank()
            {
                Id = 1,
                Name = "Ivan Ivanov",
                Nomer = 1,
                Custumers= new List<int>(){1}
            },
            new Bank()
            {
                Id = 2,
                Name = "Kiril Petrov",
                Nomer = 2,
                Custumers= new List<int>(){2}
            },
            new Bank()
            {
                Id = 3,
                Name = "Ludmil Ivanov",
                Nomer = 3,
                Custumers= new List<int>(){3}
            }
       };
    }
}

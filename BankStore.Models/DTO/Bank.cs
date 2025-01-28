namespace BankStore.Models.DTO
{
    public class Bank
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Nomer { get; set; }

        public List<string> Custumers { get; set; }
        
    }
}   
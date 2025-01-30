using BankStore.Models.DTO;
namespace BankStore.Models.Responses
{
    public class BankfulldetailsResponses
    {
        public string Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Nomer { get; set; }
        
        public List<Customers>Custumers { get; set; }=new List<Customers>();
       
    }
}

using Microsoft.AspNetCore.Mvc;
using BankStore.BL.Interfaces;
using BankStore.Models.DTO;
using BankStore.Models.Requests;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
namespace BankStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BussinesController : ControllerBase
    {
        private readonly IBussinesservises _bankservisses;
        public BussinesController(IBussinesservises bankservisses)
        {
            _bankservisses = bankservisses;
        }
        [HttpGet("GetAllDetailedBank")]
        public IActionResult GetAllDetailedBank()
        {
            var result = _bankservisses.GetAllBank();
            if(result!=null && result.Count >0)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost("Test")]
        public IActionResult Test([FromBody]  TestRequest bank)
        {
            return Ok();
        }
    }
    public class TestRequest
        {
        public int MagicNumber { get; set; }
        public string Description {  get; set; }
        public DateTime DateTime { get; set; }
        }
}

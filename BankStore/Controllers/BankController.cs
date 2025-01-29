using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using BankStore.BL.Interfaces;
using BankStore.Models.DTO;
using BankStore.Models.Requests;
using System.Runtime.CompilerServices;
namespace BankStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly IBankservises _bankservises;
        private readonly IMapper _mapper;

        public BankController(IBankservises bankservises, IMapper mapper)
        {
            _bankservises = bankservises;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _bankservises.GetAll();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest($"Wrong ID: {id}");
            }
            var result = _bankservises.GetById(id);
            if (result == null)
            {
                return NotFound($"Team with ID:{id} not found");
            }
            return Ok(result);
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody]AddBankRequests bank)
        {
            var BankDTO = _mapper.Map<Bank>(bank);
            _bankservises.Add(BankDTO);
                return Ok();
        }
        [HttpDelete("Delete")]
        public void Delete (int id)
        {
           // return _bankservises.GetById(id);
        }

    }
}

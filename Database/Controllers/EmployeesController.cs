using AutoMapper;
using Database.Data;
using Database.Dtos.Admin.Get;
using Database.Dtos.Client;
using Database.Dtos.Client.Get;
using Database.Dtos.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public GymDbContext _context { get; }
        private IMapper _mapper { get; }

        public EmployeesController(GymDbContext reactContext, IMapper mapper)
        {
            _context = reactContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ClientGet")]
        public IActionResult GetClients()
        {

            var clients = _context.Clients.ToList();
            var clientDtos = _mapper.Map<IEnumerable<PersonGetDto>>(clients);

            return Ok(clientDtos);
        }

        [HttpPut]
        [Route("UpdateClientBalance/{id:int}")]
        public IActionResult UpdateClientBalance([FromRoute] int id, [FromBody] BalanceUpdateDto dto)
        {
            var client = _context.Clients.FirstOrDefault(q => q.Id == id);

            client.Balance += dto.Balance;

            _context.SaveChanges();

            return Ok(client);
        }
    }
}

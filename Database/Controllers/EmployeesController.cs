using AutoMapper;
using Database.AdditionalRelations;
using Database.Data;
using Database.Dtos.Admin.Get;
using Database.Dtos.Client;
using Database.Dtos.Client.Get;
using Database.Dtos.Employee;
using Database.Dtos.Employee.Create;
using Database.Dtos.Employee.Get;
using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
            var client = new Client(_context);
            var clients = _context.Clients.ToList();
            var clientDtos = _mapper.Map<IEnumerable<ClientsGetDto>>(clients);

            foreach (var cl in clientDtos)
            {
                cl.GroupTokens = client.GetGroupTokens(cl.Id);
                cl.PersonalTokens = client.GetPersonalTokens(cl.Id);
            }

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

        [HttpPost]
        [Route("CreatePayment")]
        public IActionResult AddPayment(PaymentCreateDto dto)
        {
            var newPayment = _mapper.Map<Payment>(dto);

            _context.Add(newPayment);

            _context.SaveChanges();

            return Ok(newPayment);
        }

        [HttpGet]
        [Route("GetPayments")]
        public IActionResult GetPayments()
        {
            var payments = _context.Payments.Include(m => m.Client).ToList();
            var paymentsDtos = _mapper.Map<IEnumerable<PaymentGetDto>>(payments);

            return Ok(paymentsDtos);
        }
    }
}

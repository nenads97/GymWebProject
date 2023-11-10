using AutoMapper;
using Database.Authentication;
using Database.Data;
using Database.Dtos;
using Database.Dtos.Client.Create;
using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public GymDbContext _context { get; }
        private IMapper _mapper { get; }

        public ClientsController(GymDbContext reactContext, IMapper mapper)
        {
            _context = reactContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult ClientCreate([FromBody] ClientCreateDto dto)
        {
            Client newClient = _mapper.Map<Client>(dto);
            foreach (Client c in _context.Clients)
            {
                if (c.Username == newClient.Username)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Database.Authentication.Response { Status = "Error", Message = "User already exists!" });
                }
            } 
            _context.Clients.Add(newClient);
            _context.SaveChanges();
            
            return StatusCode(StatusCodes.Status201Created, new Database.Authentication.Response { Status = "Ok", Message = "User successfully added."});
        }
    }
}

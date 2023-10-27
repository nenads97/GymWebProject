using AutoMapper;
using Database.Data;
using Database.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public GymDbContext _context { get; }
        private IMapper _mapper { get; }

        public LoginController(GymDbContext reactContext, IMapper mapper)
        {
            _context = reactContext;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("{username}/{password}")]
        public IActionResult ClientCreate([FromRoute] string username, string password)
        {
            var personExist = _context.Persons.FirstOrDefault(u => u.Username == username && u.Password == password);

            var personDto = _mapper.Map<PersonLoginDto>(personExist);

            if (personDto == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return Ok(personDto);
        }

    }
}

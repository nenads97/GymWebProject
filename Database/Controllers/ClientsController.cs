using AutoMapper;
using Database.Data;
using Database.Dtos.Admin.Get;
using Database.Dtos.Client.Create;
using Database.Dtos.Client.Get;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using NPOI.XWPF.UserModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpPost]
        [Route("CreateMembership")]
        public IActionResult MembershipCreate([FromBody] MembershipCreateDto dto)
        {
            var newMembership = _mapper.Map<Membership>(dto);

            _context.Memberships.Add(newMembership);
            var membership = _context.Memberships.Include(p => p.Client).Include(p => p.Package).ToList();
            var membershipDto = _mapper.Map<IEnumerable<Membership>>(membership);

            _context.SaveChanges();

            return Ok(newMembership);
        }

        [HttpGet]
        [Route("PrintMembershipConfirmation/{id:int}")]
        public IActionResult MembershipConfirmation([FromRoute] int id)
        {
            var membership = _context.Memberships.Include(p => p.Client).Include(p => p.Package).ToList().Where(p => p.ClientId == id).FirstOrDefault();
            var membershipDto = _mapper.Map<MembershipGetDto>(membership);

            Console.WriteLine(membershipDto);

            CreateWordDoc(membershipDto.ClientName, membershipDto.ClientSurname, membershipDto.JoiningDate);

            return Ok();
        }

        [NonAction]
        public void CreateWordDoc(string firstName, string surName, DateTime joiningDate)
        {
            var doc = new XWPFDocument();
            var paragraph = doc.CreateParagraph();
            var run = paragraph.CreateRun();

            run.IsBold = true;
            run.FontSize = 18;
            run.SetText("Potvrda o uclanjenju");

            paragraph = doc.CreateParagraph();
            run = paragraph.CreateRun();
            run.FontSize = 14;
            run.SetText(firstName + " " + surName +" je uspesno uclanjen u teretanu! Datum uclanjenja: "+ joiningDate +".");

            // Čuvanje Word dokumenta na serveru (prilagodite putanju prema vašim potrebama)
            var filePath = "C:\\Users\\nsuknovic\\Desktop\\Potvrde\\PotvrdaOUclanjenju"+firstName+surName+".docx";

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                doc.Write(fileStream);
            }
        }
    }
}

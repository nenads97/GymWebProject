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
using Database.AdditionalRelations;
using Database.Dtos.Admin;
using NPOI.SS.Formula.Functions;
using System.Text.Json.Serialization;
using System.Text.Json;
using Database.Dtos.Employee;
using Database.Dtos.Client.Update;

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

            _context.Clients.Where(p => p.Id == newMembership.ClientId).FirstOrDefault().Status = Enums.Status.Active;

            _context.SaveChanges();

            return Ok();
        }
        

        [HttpPost]
        [Route("CreatePurchase")]
        public IActionResult PurchaseCreate([FromBody] PurchaseCreateDto dto)
        {
            var newPurchase = _mapper.Map<Purchase>(dto);

            _context.Purchases.Add(newPurchase);

            _context.SaveChanges();

            return Ok(newPurchase);
        }

        [HttpPost]
        [Route("CreateTokenPurchase")]
        public IActionResult TokenPurchaseCreate([FromBody] TokenPurchaseCreateDto dto)
        {
            var newTokenPurchase = _mapper.Map<TokenPurchase>(dto);

            _context.TokenPurchases.Add(newTokenPurchase);

            _context.SaveChanges();

            return Ok(newTokenPurchase);
        }

        [HttpPost]
        [Route("CreateTokenPackage")]
        public IActionResult TokenPackageCreate([FromBody] TokenPackageCreateDto dto)
        {
            var newTokenPackage = _mapper.Map<TokenPackage>(dto);

            _context.TokenPackages.Add(newTokenPackage);

            _context.SaveChanges();

            return Ok(newTokenPackage);
        }

        [HttpPost]
        [Route("CreateClientPersonalToken")]
        public IActionResult ClientPersonalTokenCreate([FromBody] ClientPersonalTokenCreateDto dto)
        {
            var newClientPersonalToken = _mapper.Map<ClientPersonalToken>(dto);

            var clientPersonalTokens = _context.ClientPersonalTokens.Include(p => p.Client).Where(p => p.ClientId == newClientPersonalToken.ClientId).ToList().Sum(p => p.NumberOfPersonalTokens);

            if (dto.NumberOfPersonalTokens < 0 && clientPersonalTokens < Math.Abs(dto.NumberOfPersonalTokens))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Database.Authentication.Response { Status = "Error", Message = "Not enough tokens for that!" });

            }
            else
            {
                _context.ClientPersonalTokens.Add(newClientPersonalToken);

                _context.SaveChanges();

                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    PropertyNamingPolicy = null
                };

                var json = JsonSerializer.Serialize(clientPersonalTokens, jsonOptions);
                return Ok(json);
            }
        }

        [HttpPost]
        [Route("CreateClientGroupToken")]
        public IActionResult ClientGroupTokenCreate([FromBody] ClientGroupTokenCreateDto dto)
        {
            var newClientGroupToken = _mapper.Map<ClientGroupToken>(dto);

            var clientGroupTokens = _context.ClientGroupTokens.Include(p => p.Client).Where(p => p.ClientId == newClientGroupToken.ClientId).ToList().Sum(p => p.NumberOfGroupTokens);

            if (dto.NumberOfGroupTokens < 0 && clientGroupTokens < Math.Abs(dto.NumberOfGroupTokens))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Database.Authentication.Response { Status = "Error", Message = "Not enough tokens for that!" });

            }
            else
            {
                _context.ClientGroupTokens.Add(newClientGroupToken);

                _context.SaveChanges();

                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    PropertyNamingPolicy = null
                };

                var json = JsonSerializer.Serialize(clientGroupTokens, jsonOptions);
                return Ok(json);
            }
        }



        // ***********************************
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
        

        [HttpGet]
        [Route("GetClientPersonalTokens/{id}")]
        public IActionResult ClientPersonalTokensGet([FromRoute] int id)
        {
            var sum = _context.ClientPersonalTokens.Include(p => p.Client).Where(p => p.ClientId == id).ToList().Sum(p => p.NumberOfPersonalTokens);
            var clientPersonalTokens = _context.ClientPersonalTokens.Include(p => p.Client).Where(p => p.ClientId == id).FirstOrDefault();
            if (clientPersonalTokens != null)
            {
                clientPersonalTokens.NumberOfPersonalTokens = sum;
            }

            var clientGroupTokensDtos = _mapper.Map<ClientPersonalTokenGetDto>(clientPersonalTokens);

            return Ok(clientGroupTokensDtos);
        }

        [HttpGet]
        [Route("GetClientGroupTokens/{id}")]
        public IActionResult ClientGroupTokensGet([FromRoute] int id)
        {
            var client = new Client(_context);
            int sum = client.GetGroupTokens(id);

            var clientGroupTokens = _context.ClientGroupTokens.Include(p => p.Client).Where(p => p.ClientId == id).FirstOrDefault();
            if (clientGroupTokens != null)
            {
                clientGroupTokens.NumberOfGroupTokens = sum;
            }

            var clientGroupTokensDtos = _mapper.Map<ClientGroupTokenGetDto>(clientGroupTokens);

            return Ok(clientGroupTokensDtos);
        }

        [HttpGet]
        [Route("GetTokenPackage")]
        public IActionResult TokenPackageGet()
        {
            var tokenPackages = _context.TokenPackages.ToList();
            var tokenPackagesDto = _mapper.Map<IEnumerable<TokenPackageGetDto>>(tokenPackages);


            return Ok(tokenPackagesDto);
        }

        [HttpGet]
        [Route("GetTokens")]
        public IActionResult TokensGet()
        {
            var tokens = _context.Tokens.Include(p => p.TokenPrices).ToList();
            var tokensDtos = _mapper.Map<IEnumerable<TokensGetDto>>(tokens);

            return Ok(tokensDtos);
        }

        [HttpGet]
        [Route("GetClientMembership/{id}")]
        public IActionResult MembershipsGet([FromRoute] int id)
        {
            var membership = _context.Memberships.Include(p => p.Package).Include(c => c.Client).Where(p => p.ClientId == id).FirstOrDefault();
            var membershipDto = _mapper.Map<MembershipGetDto>(membership);

            return Ok(membershipDto);
        }

        //UPDATE

        [HttpPut]
        [Route("UpdateClientStatus/{id:int}")]
        public IActionResult UpdateClientStatus([FromRoute] int id, StatusUpdateDto dto)
        {
            var client = _context.Clients.FirstOrDefault(q => q.Id == id);

            client.Status = dto.Status;

            _context.SaveChanges();

            return Ok(client);
        }


        //NON ACTION

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

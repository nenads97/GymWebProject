﻿using AutoMapper;
using Database.AdditionalRelations;
using Database.Data;
using Database.Dtos.Admin;
using Database.Dtos.Admin.Create;
using Database.Dtos.Admin.Get;
using Database.Entities;
using Database.JoinTables;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Database.Dtos.Client.Create;
using Database.Dtos.Client.Get;
using Database.Dtos.Employee.Get;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        public GymDbContext _context { get; }
        private IMapper _mapper { get; }

        public AdministratorsController(GymDbContext reactContext, IMapper mapper)
        {
            _context = reactContext;
            _mapper = mapper;
        }

        //CREATE

        [HttpPost]
        [Route("PackagePriceCreate")]
        public IActionResult PackagePriceCreate([FromBody] PackagePriceCreateDto dto)
        {
            var newPrice = _mapper.Map<PackagePrice>(dto);

            _context.PackagePrices.Add(newPrice);
            _context.SaveChanges();

            return Ok(newPrice);
        }

        [HttpPost]
        [Route("PackageTokenCreate")]
        public IActionResult PackageTokenCreate([FromBody] TokenPackageCreateDto dto)
        {
            var tokenPackage = _mapper.Map<TokenPackage>(dto);

            _context.TokenPackages.Add(tokenPackage);
            _context.SaveChanges();

            return Ok(tokenPackage);
        }

        [HttpPost]
        [Route("PackageDiscountCreate")]
        public IActionResult PackageDiscountCreate([FromBody] PackageDiscountCreateDto dto)
        {
            var newDiscount = _mapper.Map<PackageDiscount>(dto);
                _context.PackageDiscounts.Add(newDiscount);
                _context.SaveChanges();
                return Ok(newDiscount);
        }

        [HttpPost]
        [Route("PackageCreate")]
        public IActionResult PackageCreate([FromBody] PackageCreateDto dto)
        {
            var newPackage = _mapper.Map<Package>(dto);

            newPackage.Administrator = _context.Administraotrs.Find(dto.AdministratorId);
            var newPackageAdmin = new PackageAdministrator
            {
                Administrator = newPackage.Administrator,
                Package = newPackage
            };

            _context.PackageAdministrators.Add(newPackageAdmin);
            _context.Packages.Add(newPackage);
            _context.SaveChanges();


            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                PropertyNamingPolicy = null
            };

            var json = JsonSerializer.Serialize(newPackage, jsonOptions);
            return Ok(json);
        }

        [HttpPost]
        [Route("PackageDiscountSet")]
        public IActionResult PackageDiscountSet([FromBody] PackageDiscountSetDto dto)
        {
            var newDiscount = _mapper.Map<PackagePackageDiscount>(dto);

            _context.PackagePackageDiscounts.Add(newDiscount);
            _context.SaveChanges();

            return Ok(newDiscount);
        }

        [HttpPost]
        [Route("TrainerCreate")]
        public IActionResult TrainerCreate([FromBody] TrainerCreateDto dto)
        {
            var newTrainer = _mapper.Map<Trainer>(dto);

            _context.Trainers.Add(newTrainer);
            _context.SaveChanges();

            return Ok(newTrainer);
        }

        [HttpPost]
        [Route("EmployeeCreate")]
        public IActionResult EmployeeCreate([FromBody] EmployeeCreateDto dto)
        {
            var newEmployee = _mapper.Map<Employee>(dto);

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return Ok(newEmployee);
        }

        [HttpPost]
        [Route("CreateTokenPrice")]
        public IActionResult TokenPriceCreate([FromBody] TokenPriceCreateDto dto)
        {
            var newTokenPrice = _mapper.Map<TokenPrice>(dto);

            _context.TokenPrices.Add(newTokenPrice);

            _context.SaveChanges();

            return Ok(newTokenPrice);
        }

        [HttpPost]
        [Route("CreateToken")]
        public IActionResult TokenCreate([FromBody] TokenCreateDto dto)
        {
            var newToken = _mapper.Map<Token>(dto);

            _context.Tokens.Add(newToken);

            _context.SaveChanges();

            return Ok(newToken);
        }

        //UPDATE

        [HttpPut]
        [Route("UpdateTrainer/{id:int}")]
        public IActionResult UpdateTrainer([FromRoute] int id, [FromBody] TrainerCreateDto dto)
        {
            var trainer = _context.Trainers.FirstOrDefault(q => q.Id == id);
            if (trainer is null)
            {
                return NotFound("Car Not Found");
            }

            trainer.JMBG = dto.JMBG;
            trainer.Firstname = dto.Firstname;
            trainer.Surname = dto.Surname;
            trainer.PhoneNumber = dto.PhoneNumber;
            trainer.Gender = dto.Gender;
            trainer.Email = dto.Email;
            trainer.Password = dto.Password;

            var trainerDto = _mapper.Map<PersonGetDto>(trainer);

            _context.SaveChanges();

            return Ok(trainerDto);
        }

        [HttpPut]
        [Route("UpdateEmployee/{id:int}")]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromBody] EmployeeCreateDto dto)
        {
            var employee = _context.Employees.FirstOrDefault(q => q.Id == id);
            if (employee is null)
            {
                return NotFound("Employee Not Found");
            }
            
            employee.JMBG = dto.JMBG;
            employee.Firstname = dto.Firstname;
            employee.Surname = dto.Surname;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.Gender = dto.Gender;
            employee.Email = dto.Email;
            employee.Password = dto.Password;

            var employeeDto = _mapper.Map<PersonGetDto>(employee);


            _context.SaveChanges();

            return Ok(employeeDto);
        }

        [HttpPut]
        [Route("UpdateClient/{id:int}")]
        public IActionResult UpdateClient([FromRoute] int id, [FromBody] ClientCreateDto dto)
        {
            var client = _context.Clients.FirstOrDefault(q => q.Id == id);
            if (client is null)
            {
                return NotFound("Client Not Found");
            }

            client.JMBG = dto.JMBG;
            client.Firstname = dto.Firstname;
            client.Surname = dto.Surname;
            client.PhoneNumber = dto.PhoneNumber;
            client.Gender = dto.Gender;
            client.Email = dto.Email;
            client.Password = dto.Password;

            var clientDto = _mapper.Map<PersonGetDto>(client);


            _context.SaveChanges();

            return Ok(clientDto);
        }

        

        // GET

        [HttpGet]
        [Route("PackageGet")]
        public IActionResult GetPackages()
        {
            
            var packages = _context.Packages.Include(p => p.PackagePrices).Include(p => p.TokenPackages).ThenInclude(p => p.Token).Include(p => p.PackagePackageDiscounts).ThenInclude(p => p.PackageDiscount).ToList();
            var packageDtos = _mapper.Map<IEnumerable<PackageGetDto>>(packages);

            return Ok(packageDtos);
        }

        [HttpGet]
        [Route("PackageGetCurrent/{id:int}")]
        public IActionResult GetCurrentPackage([FromRoute] int id)
        {

            //var packages = _context.Packages.Include(p => p.PackagePrices).Include(p => p.TokenPackages).ThenInclude(p => p.Token).Include(p => p.PackagePackageDiscounts).ThenInclude(p => p.PackageDiscount).ToList();

            var package = _context.Packages.Include(p => p.PackagePrices).Include(p => p.TokenPackages).ThenInclude(p => p.Token).Include(p => p.PackagePackageDiscounts).ThenInclude(p => p.PackageDiscount).FirstOrDefault(d => d.PackageId == id);
            var packageDto = _mapper.Map<PackageGetDto>(package);

            if (package is null)
            {
                return NotFound("Admin not found.");
            }

            return Ok(packageDto);
        }

        [HttpGet]
        [Route("ClientGet")]
        public IActionResult GetClients()
        {

            var clients = _context.Clients.ToList();
            var clientDtos = _mapper.Map<IEnumerable<PersonGetDto>>(clients);

            return Ok(clientDtos);
        }

        [HttpGet]
        [Route("EmployeeGet")]
        public IActionResult GetEmployees()
        {

            var employees = _context.Employees.ToList();
            var employeeDtos = _mapper.Map<IEnumerable<PersonGetDto>>(employees);

            return Ok(employeeDtos);
        }

        [HttpGet]
        [Route("TrainerGet")]
        public IActionResult GetTrainers()
        {

            var trainers = _context.Trainers.ToList();
            var trainerDtos = _mapper.Map<IEnumerable<PersonGetDto>>(trainers);

            return Ok(trainerDtos);
        }

        [HttpGet]
        [Route("AdminGetCurrent/{id:int}")]
        public IActionResult GetCurrentAdmin([FromRoute] int id)
        {

            var admin = _context.Administraotrs.FirstOrDefault(d => d.Id == id);
            var adminDto = _mapper.Map<PersonGetDto>(admin);

            if (admin is null)
            {
                return NotFound("Admin not found.");
            }

            return Ok(adminDto);
        }

        [HttpGet]
        [Route("TrainerGetCurrent/{id:int}")]
        public IActionResult GetCurrentTrainer([FromRoute] int id)
        {

            var trainer = _context.Trainers.FirstOrDefault(d => d.Id == id);
            var trainerDto = _mapper.Map<PersonGetDto>(trainer);

            if (trainer is null)
            {
                return NotFound("Trainer not found.");
            }

            return Ok(trainerDto);
        }

        [HttpGet]
        [Route("EmployeeGetCurrent/{id:int}")]
        public IActionResult GetCurrentEmployee([FromRoute] int id)
        {

            var employee = _context.Employees.FirstOrDefault(d => d.Id == id);
            var employeeDto = _mapper.Map<PersonGetDto>(employee);

            if (employee is null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employeeDto);
        }

        [HttpGet]
        [Route("ClientGetCurrent/{id:int}")]
        public IActionResult GetCurrentClient([FromRoute] int id)
        {

            var client = _context.Clients.FirstOrDefault(d => d.Id == id);
            var clientDto = _mapper.Map<ClientsGetDto>(client);

            if (client is null)
            {
                return NotFound("Client not found.");
            }

            return Ok(clientDto);
        }

        [HttpGet]
        [Route("TokenGetCurrent/{id:int}")]
        public IActionResult GetCurrentToken([FromRoute] int id)
        {

            var token = _context.Tokens.Include(p => p.TokenPrices).FirstOrDefault(d => d.TokenId == id);
            var tokenDto = _mapper.Map<TokensGetDto>(token);

            if (token is null)
            {
                return NotFound("Token not found.");
            }

            return Ok(tokenDto);
        }

        [HttpGet]
        [Route("TokenPricesGet")]
        public IActionResult GetTokenPrices()
        {

            var tokenPrices = _context.TokenPrices.Include(p => p.Token).ToList();
            var tokenPricesDto = _mapper.Map<IEnumerable<TokenPricesGetDto>>(tokenPrices);
            Console.WriteLine();

            return Ok(tokenPricesDto);
        }


        [HttpGet]
        [Route("PackageDiscountGet")]
        public IActionResult GetPackageDiscounts()
        {

            var packageDiscounts = _context.PackageDiscounts.Include(p => p.PackagePackageDiscounts).ThenInclude(p => p.Package).ToList();
            var packageDiscountsDtos = _mapper.Map<IEnumerable<PackageDiscountGetDto>>(packageDiscounts);
            Console.WriteLine();

            return Ok(packageDiscountsDtos);
        }

        [HttpGet]
        [Route("PackagePackageDiscountGet")]
        public IActionResult GetPackagePackageDiscounts()
        {

            var packageDiscounts = _context.PackagePackageDiscounts.Include(p => p.PackageDiscount).Include(p => p.Package).ToList();
            var packageDiscountsDtos = _mapper.Map<IEnumerable<PackagePackageDiscountGetDto>>(packageDiscounts);
            Console.WriteLine();

            return Ok(packageDiscountsDtos);
        }

        [HttpGet]
        [Route("PackagePriceGet")]
        public IActionResult GetPackagePrices()
        {

            var packagePrices = _context.PackagePrices.Include(p => p.Package).ToList();
            var packagePricesDtos = _mapper.Map<IEnumerable<PackagePriceGetDto>>(packagePrices);

            return Ok(packagePricesDtos);
        }

        [HttpGet]
        [Route("TokensGet")]
        public IActionResult TokensGet()
        {
            var tokens = _context.Tokens.Include(p => p.TokenPrices).ToList();
            var tokenPricesDtos = _mapper.Map<IEnumerable<TokensGetDto>>(tokens);

            return Ok(tokenPricesDtos);
        }

        // DELETE

        [HttpDelete]
        [Route("RemoveClient/{id:int}")]
        public IActionResult RemoveClient([FromRoute] int id)
        {
            var client = _context.Clients.FirstOrDefault(q => q.Id == id);

            if (client is null)
            {
                return NotFound("Employee Not Found");
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return Ok("Client Deleted Successfully");
        }

        [HttpDelete]
        [Route("RemoveEmployee/{id:int}")]
        public  IActionResult RemoveEmployee([FromRoute] int id)
        {
            var employee = _context.Employees.FirstOrDefault(q => q.Id == id);

            if (employee is null)
            {
                return NotFound("Employee Not Found");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok("Employee Deleted Successfully");
        }

        [HttpDelete]
        [Route("RemoveTrainer/{id:int}")]
        public IActionResult RemoveTrainer([FromRoute] int id)
        {
            var trainer = _context.Trainers.FirstOrDefault(q => q.Id == id);

            if (trainer is null)
            {
                return NotFound("Trainer Not Found");
            }

            _context.Trainers.Remove(trainer);
            _context.SaveChanges();

            return Ok("Trainer Deleted Successfully");
        }

        [HttpDelete]
        [Route("RemovePackage/{id:int}")]
        public IActionResult RemovePackage([FromRoute] int id)
        {
            var package = _context.Packages.FirstOrDefault(q => q.PackageId == id);
            var adminPackage = _context.PackageAdministrators.FirstOrDefault(q => q.PackageId == id);
            var packageDiscounts = _context.PackagePackageDiscounts.ToList();
            var packagePrices = _context.PackagePrices.ToList();
            var tokenPackages = _context.TokenPackages.ToList();


            if (package is null)
            {
                return NotFound("Package Not Found");
            }

            foreach (var disc in packageDiscounts)
            {
                if (disc.PackageId == id)
                {
                    _context.PackagePackageDiscounts.Remove(disc);
                }
            }
            foreach (var price in packagePrices)
            {
                if (price.PackageId == id)
                {
                    _context.PackagePrices.Remove(price);
                }
            }
            foreach (var token in tokenPackages)
            {
                if (token.PackageId == id)
                {
                    _context.TokenPackages.Remove(token);
                }
            }

            _context.PackageAdministrators.Remove(adminPackage);
            _context.Packages.Remove(package);
            
            _context.SaveChanges();

            return Ok("Package Deleted Successfully");
        }
    }
}

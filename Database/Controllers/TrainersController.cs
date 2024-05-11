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
using Database.Dtos.Trainer;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        public GymDbContext _context { get; }
        private IMapper _mapper { get; }

        public TrainersController(GymDbContext reactContext, IMapper mapper)
        {
            _context = reactContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateApplication")]
        public IActionResult CreateApplication(ApplicationDto applicationDto)
        {
            var application = _mapper.Map<Application>(applicationDto);
            var resault = _context.Applications.Add(application);

            _context.Applications.Add(application);
            _context.SaveChanges();

            return Ok(resault);
        }

        [HttpGet]
        [Route("GetAllApplications")]
        public IActionResult GetAllApplications()
        {
            var applications = _context.Applications.ToList();
            var applicationsDto = _mapper.Map<ApplicationDto>(applications);

            return Ok(applicationsDto);
        }

        [HttpDelete]
        [Route("RemoveApplication/{id:int}")]
        public IActionResult RemoveApplication([FromRoute]int id)
        {
            var application = _context.Applications.FirstOrDefault(q => q.ApplicationId == id);

            if (application is null)
            {
                return NotFound("Employee Not Found");
            }

            _context.Applications.Remove(application);
            _context.SaveChanges();

            return Ok();
        }
    }
}

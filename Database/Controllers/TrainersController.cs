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
using Database.Enums;
using Database.Dtos.Admin.Create;

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
        [Route("CreateTraining")]
        public IActionResult CreateTraining(TrainingDto groupTraining)
        {
            var application = _mapper.Map<Training>(groupTraining);

            TrainerTrainingSignUp trainerTrainingSignUp = new TrainerTrainingSignUp();
            trainerTrainingSignUp.TrainerId = application.TrainerId;
            trainerTrainingSignUp.TrainingId = application.TrainingId;
            trainerTrainingSignUp.DatumZakazivanja = DateTime.Now;

            _context.TrainerTrainingSignUps.Add(trainerTrainingSignUp);
            _context.Trainings.Add(application);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("CreateApplication")]
        public IActionResult CreateApplication(ApplicationDto applicationDto)
        {
            var application = _mapper.Map<Application>(applicationDto);
            _context.Applications.Add(application);

            _context.Applications.Add(application);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("CreateResponse")]
        public IActionResult CreateResponse([FromBody] ResponseDto dto)
        {

            var response = new Response() { RequestId = dto.RequestId, Content = dto.Content, TrainerId = dto.TrainerId };

            _context.Responses.Add(response);
            _context.SaveChanges();
            var resp = _context.Responses.FirstOrDefault(r => r.RequestId == dto.RequestId);

            var request = _context.Requests.FirstOrDefault(x => x.RequestId == dto.RequestId);

            var clientRequest = _context.ClientRequests.FirstOrDefault(x => x.RequestId == dto.RequestId);

            request.ResponseId = resp.ResponseId;

            if (response.Content)
            {
                request.Status = RequestStatus.Accepted; 
                var personalTraining = new PersonalTraining(Category.Personal, request.Duration, request.DateAndTimeOfRequestOpening, dto.Description, response.TrainerId);
                personalTraining.RequestId = dto.RequestId;
                Random random = new Random();
                int randomNumber = random.Next(10000, 100000);
                personalTraining.TrainingId = randomNumber;

                _context.PersonalTrainings.Add(personalTraining);
                request.PersonalTrainingId = personalTraining.TrainingId;

                _context.ClientPersonalTokens.Add(new ClientPersonalToken { ClientId = clientRequest.ClientId, PersonalTokenId = 1, NumberOfPersonalTokens = -1 });
            }

            else
            {
                request.Status = RequestStatus.Rejected;
            }

            _context.Requests.Update(request);

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("GetAllApplications")]
        public IActionResult GetAllApplications()
        {
            // Fetch applications and include the necessary related entities
            var applications = _context.Applications
                .Include(a => a.Trainer)
                .Include(a => a.GroupTraining)
                .ToList();

            var applicationDtos = applications.Select(application => new AllApplicationsDto
            {
                Firstname = application.Trainer.Firstname,
                Surname = application.Trainer.Surname,
                EventDate = application.EventDate,
                NumberOfSpots = application.numberOfSpots,
                GroupTrainingId = application.GroupTrainingId,
                TrainingId = application.GroupTraining.TrainingId,
                TrainingType = application.GroupTraining.TrainingType,
                Duration = application.GroupTraining.Duration,
                OpeningDate = application.OpeningDate,
                Description = application.GroupTraining.Description,
                TrainerId = application.TrainerId,
                TrainingStatus = application.GroupTraining.Status,
                NumberOfReservedSpots = application.numberOfReservedSpots,
                ApplicationId = application.ApplicationId
            }).ToList();

            return Ok(applicationDtos);
        }

        [HttpGet]
        [Route("GetAllRequestsForSpecificTrainer/{id:int}")]
        public IActionResult GetAllRequestsForSpecificTrainer([FromRoute] int id)
        {
            var requests = _context.ClientRequests.Include(a => a.Client).Include(a => a.Request).Where(a => a.TrId == id).ToList();

            var requestsDtos = requests.Select(request => new ClientRequestsDto
            {
                RequestId = request.Request.RequestId,
                Duration = request.Request.Duration,
                FullName = request.Client.Firstname + " " + request.Client.Surname,
                Gender = request.Client.Gender,
                Email = request.Client.Email,
                PhoneNumber = request.Client.PhoneNumber,
                DateAndTimeOfMaintenance = request.Request.DateAndTimeOfRequestOpening,
                RequestStatus = request.Request.Status
            }) ;

            return Ok(requestsDtos);
        }

            [HttpGet]
        [Route("GetAllPersonalTrainings/{id:int}")]
        public IActionResult GetAllPersonalTrainings([FromRoute] int id)
        {
            var applications = _context.Trainings.Where(a => a.TrainerId == id && a.TrainingType == Category.Personal).ToList();

            return Ok(applications);
        }


        [HttpGet]
        [Route("GetAllApplicationsForSpecificTrainer/{id:int}")]
        public IActionResult GetAllApplicationsForSpecificTrainer([FromRoute]int id)
        {
            var applications = _context.Applications.Where(a => a.TrainerId == id).Include(a => a.GroupTraining).ToList();

            return Ok(applications);
        }

        [HttpPut]
        [Route("ChangeTrainingStatusToCanceled/{id:int}")]
        public IActionResult ChangeTrainingStatusToCanceled([FromRoute] int id)
        {
            var training = _context.Trainings.FirstOrDefault(a => a.TrainingId == id);
            training.Status = Enums.TrainingStatus.Canceled;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("ChangeTrainingStatusToHeld/{id:int}")]
        public IActionResult ChangeTrainingStatusToHeld([FromRoute] int id)
        {
            var training = _context.Trainings.FirstOrDefault(a => a.TrainingId == id);
            training.Status = Enums.TrainingStatus.Held;

            _context.SaveChanges();

            return Ok();
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

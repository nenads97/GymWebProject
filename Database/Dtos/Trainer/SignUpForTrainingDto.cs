using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Dtos.Trainer
{
    public class SignUpForTrainingDto
    {
        public DateTime DateAndTimeOfSignUp { get; set; }
        public int ClientId { get; set; }
        public int ApplicationId { get; set; }
    }
}

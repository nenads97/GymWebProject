using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Dtos.Trainer
{
    public class SignOutFromTrainingDto
    {
        public DateTime DateTimeOfSignOut { get; set; }
        public int ClientId { get; set; }
        public int ApplicationId { get; set; }
    }
}

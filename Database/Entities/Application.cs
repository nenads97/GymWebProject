using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime OpeningDate { get; set; }
        public int numberOfSpots { get; set; }

        public ICollection<SignUpForTraining> SignUp { get; set; }
        public ICollection<SignOutFromTraining> SignOut { get; set; }

        public int GroupTrainingId { get; set; }
        public virtual GroupTraining GroupTraining { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}

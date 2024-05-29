using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.AdditionalRelations;
using Database.Enums;

namespace Database.Entities
{
    public class Training
    {
        public Training(Category trainingType, int duration, DateTime dateAndTime, string description, int trainerId)
        {
            TrainingType = trainingType;
            Duration = duration;
            DateAndTime = dateAndTime;
            Description = description;
            TrainerId = trainerId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainingId { get; set; }
        public Category TrainingType { get; set; }
        public int Duration { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public TrainingStatus Status { get; set; } = TrainingStatus.Available;

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        [ForeignKey("TrainerTrainingSignOut")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TrainerTrainingSignOutId { get; set; }
        public virtual TrainerTrainingSignOut? TrainerTrainingSignOut { get; set; }

        [ForeignKey("TrainerTrainingSignUp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TrainerTrainingSignUpId { get; set; }
        public virtual TrainerTrainingSignUp? TrainerTrainingSignUp { get; set; }
    }
}

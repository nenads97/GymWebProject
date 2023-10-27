using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.AdditionalRelations;
using Database.Enums;

namespace Database.Entities
{
    public class Training
    {
        public Training(int trainingId, Category trainingType, int duration, DateTime dateAndTime, string description)
        {
            TrainingId = trainingId;
            TrainingType = trainingType;
            Duration = duration;
            DateAndTime = dateAndTime;
            Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingId { get; set; }
        public Category TrainingType { get; set; }
        public int Duration { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        [ForeignKey("TrainerTrainingSignOut")]
        public int TrainerTrainingSignOutId { get; set; }
        public virtual TrainerTrainingSignOut TrainerTrainingSignOut { get; set; }

        [ForeignKey("TrainerTrainingSignUp")]
        public int TrainerTrainingSignUpId { get; set; }
        public virtual TrainerTrainingSignUp TrainerTrainingSignUp { get; set; }
    }
}

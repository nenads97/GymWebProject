using Database.Enums;

namespace Database.Dtos.Trainer
{
    public class AllApplicationsDto
    {
        public int ApplicationId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime EventDate { get; set; }
        public int NumberOfSpots { get; set; }
        public int GroupTrainingId { get; set; }
        public int NumberOfReservedSpots { get; set; }

        //training
        public int? TrainingId { get; set; }
        public Category TrainingType { get; set; }
        public int Duration { get; set; }
        public DateTime OpeningDate { get; set; }
        public string Description { get; set; }
        public int TrainerId { get; set; }
        public Enums.TrainingStatus TrainingStatus { get; set; }
    }
}

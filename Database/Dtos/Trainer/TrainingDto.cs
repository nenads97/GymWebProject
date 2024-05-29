using Database.Enums;

namespace Database.Dtos.Trainer
{
    public class TrainingDto
    {
        public int? TrainingId { get; set; }
        public Category TrainingType { get; set; }
        public int Duration { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Description { get; set; }
        public int TrainerId { get; set; }

    }
}

namespace Database.Dtos.Trainer
{
    public class ApplicationDto
    {
        public DateTime EventDate { get; set; }
        public int NumberOfSpots { get; set; }
        public int TrainerId { get; set; }
        public int GroupTrainingId { get; set; }
    }
}

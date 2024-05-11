namespace Database.Dtos.Trainer
{
    public class ApplicationDto
    {
        public DateTime EventDate { get; set; }
        public DateTime OpeningDate { get; set; }
        public int numberOfSpots { get; set; }
        public int GroupTrainingId { get; set; }
        public int TrainerId { get; set; }
    }
}

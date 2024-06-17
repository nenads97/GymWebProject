namespace Database.Dtos.Employee.Get
{
    public class PersonalTrainingDto
    {
        public string TrainerName { get; set; }
        public string ClientName { get; set; }
        public DateTime DateAndTimeOfMaitenance { get; set; }
        public int Duration { get; set; }
        public Enums.TrainingStatus TrainingStatus { get; set; }
    }
}

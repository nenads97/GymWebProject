namespace Database.Dtos.Client.Create
{
    public class ClientRequestDto
    {
        public DateTime DateAndTimeOfRequestOpening { get; set; }
        public int ClientId { get; set; }
        public int? ResponseId { get; set; }
        public int? PersonalTrainingId { get; set; }
        //public int? ClientRequestId { get; set; }
    }
}

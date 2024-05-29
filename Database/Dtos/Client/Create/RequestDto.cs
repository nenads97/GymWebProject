namespace Database.Dtos.Client.Create
{
    public class RequestDto
    {
        public DateTime DateAndTimeOfRequestOpening { get; set; }
        public int ClientRequestId { get; set; }
        public int? ResponseId { get; set; }

    }
}

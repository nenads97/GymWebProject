using Database.Enums;

namespace Database.Dtos.Client.Create
{
    public class ClientRequestsDto
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public DateTime DateAndTimeOfMaintenance { get; set; }
        public RequestStatus RequestStatus { get;set; }
    }
}

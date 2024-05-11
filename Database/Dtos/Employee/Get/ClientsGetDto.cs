using Database.Enums;

namespace Database.Dtos.Employee.Get
{
    public class ClientsGetDto
    {
        public int Id { get; set; }
        public long JMBG { get; set; }
        public double PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public double Balance { get; set; }
        public Status Status { get; set; }
        public int PersonalTokens { get; set; }
        public int GroupTokens { get; set; }
    }
}

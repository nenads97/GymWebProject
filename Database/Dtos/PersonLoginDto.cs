using Database.Enums;

namespace Database.Dtos
{
    public class PersonLoginDto
    {
        public int Id { get; set; }
        public long JMBG { get; set; }
        public double PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
    }
}

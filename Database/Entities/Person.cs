using Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Person
    {
        public Person() { 
        }
        protected Person(int id,long jMBG, double phoneNumber, string password, string username, Gender gender, Role role, string email, string surname, string firstname)
        {
            this.id = id;
            this.jMBG = jMBG;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.username = username;
            this.gender = gender;
            this.role = role;
            this.email = email;
            this.surname = surname;
            this.firstname = firstname;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private long jMBG;
        private double phoneNumber;
        private string password;
        private string username;
        private Gender gender;
        private Role role;
        private string email;
        private string surname;
        private string firstname;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "JMBG is required!")]
        public long JMBG { get => jMBG; set => jMBG = value; }
        [Required(ErrorMessage = "Phone number is required!")]
        public double PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get => password; set => password = value; }
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get => username; set => username = value; }
        [Required(ErrorMessage = "Gender is required!")]
        public Gender Gender { get => gender; set => gender = value; }
        public Role Role { get => role; set => role = value; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get => email; set => email = value; }
        [Required(ErrorMessage = "Surname is required!")]
        public string Surname { get => surname; set => surname = value; }
        [Required(ErrorMessage = "Firstname is required!")]
        public string Firstname { get => firstname; set => firstname = value; }
    }
}


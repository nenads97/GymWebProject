using Database.Enums;

namespace Database.Entities
{
    public class Employee : Person
    {
        public Employee()
        { 
            Role = Role.Employee;
        }
        protected Employee(int id, long jMBG, double phoneNumber, string password, string username, Gender gender, Role role, string email, string surname, string firstname) : base(id, jMBG, phoneNumber, password, username, gender, role, email, surname, firstname)
        {
            Role = Role.Employee;
        }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

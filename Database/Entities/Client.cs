using AutoMapper;
using Database.AdditionalRelations;
using Database.Data;
using Database.Enums;
using System.Data.Entity;

namespace Database.Entities
{
    public class Client : Person
    {
        public GymDbContext _context { get; }

        public Client(GymDbContext reactContext)
        {
            _context = reactContext;
        }

        public Client() {
            Balance = 0;
            Role = Role.Client;
            Status = Status.Inactive;
        }
        public Client(int id, long jMBG, double phoneNumber, string password, string username, Gender gender, string email, string surname, string firstname, double balance, Role role, Status status) : base(id, jMBG, phoneNumber, password, username, gender, role, email, surname, firstname)
        {
            Balance = balance;
            Role = Role.Client;
            Status = Status.Inactive;
        }
        private double balance;
        private Status status;

        public double Balance { get => balance; set => balance = value; }
        public Status Status { get => status; set => status = value; }


        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<ClientRequest> ClientRequests { get; set; }
        public virtual ICollection<SignUpForTraining> SignUpsForTraining { get; set; }
        public virtual ICollection<SignOutFromTraining> SignOutsFromTraining { get; set; }
        
        public virtual ICollection<ClientGroupToken> ClientGroupTokens { get; set; }
        public virtual ICollection<ClientPersonalToken> ClientPersonalTokens { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; } 

        public int GetGroupTokens (int id)
        {
            var sum = _context.ClientGroupTokens.Include(p => p.Client).Where(p => p.ClientId == id).ToList().Sum(p => p.NumberOfGroupTokens);

            return sum;
        }

        public int GetPersonalTokens(int id)
        {
            var sum = _context.ClientPersonalTokens.Include(p => p.Client).Where(p => p.ClientId == id).ToList().Sum(p => p.NumberOfPersonalTokens);

            return sum;
        }
    }
}

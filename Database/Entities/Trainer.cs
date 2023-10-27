using Database.AdditionalRelations;
using Database.Enums;

namespace Database.Entities
{
    public class Trainer : Person
    {
        public Trainer()
        {
            Role = Role.Trainer;
        }
        protected Trainer(int id, long jMBG, double phoneNumber, string password, string username, Gender gender, Role role, string email, string surname, string firstname) : base(id,jMBG, phoneNumber, password, username, gender, role, email, surname, firstname)
        {
            Role = Role.Trainer;
        }

        /*
        public ICollection<Response> Responses { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public ICollection<TrainerTrainingSignOut> TrainerTrainingSignOuts { get; set; }
        public ICollection<TrainerTrainingSignUp> TrainerTrainingSignUps { get; set; }
        */
    }
}

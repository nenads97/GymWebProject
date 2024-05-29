using Database.AdditionalRelations;
using Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class PersonalTraining : Training
    {
        public PersonalTraining(Category trainingType, int duration, DateTime dateAndTime, string description, int trainerId) : base(trainingType, duration, dateAndTime, description, trainerId)
        {
        }

        [ForeignKey("Request")]
        public int? RequestId { get; set; }
        public Request Request { get; set; }

        public ICollection<PTokenPTraining> PTokenPTraining { get; set; }
    }
}

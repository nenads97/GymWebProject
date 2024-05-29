using Database.AdditionalRelations;
using Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class GroupTraining : Training
    {
        public GroupTraining(Category trainingType, int duration, DateTime dateAndTime, string description, int trainerId) : base(trainingType, duration, dateAndTime, description, trainerId)
        {
        }

        [ForeignKey("SignUpForTrainingFK")]
        public int? SignUpId { get; set; }
        public virtual SignUpForTraining SignUp { get; set; }

        public ICollection<GTokenGTraining> GTokenGTraining { get; set; }
    }
}

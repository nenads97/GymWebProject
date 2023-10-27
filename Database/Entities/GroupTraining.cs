using Database.AdditionalRelations;
using Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class GroupTraining : Training
    {
        public GroupTraining(int trainingId, Category trainingType, int duration, DateTime dateAndTime, string description) : base(trainingId, trainingType, duration, dateAndTime, description)
        {
        }

        [ForeignKey("SignUpForTrainingFK")]
        public int? SignUpId { get; set; }
        public virtual SignUpForTraining SignUp { get; set; }

        public ICollection<GTokenGTraining> GTokenGTraining { get; set; }
    }
}

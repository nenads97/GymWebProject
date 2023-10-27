using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.Entities;

namespace Database.AdditionalRelations
{
    public class GTokenGTraining
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GTrainingGTokenId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("GroupTraining")]
        public int GroupTrainingId { get; set; }
        public GroupTraining GroupTraining { get; set; }

        [ForeignKey("GroupToken")]
        public int GroupTokenId { get; set; }
        public GroupToken GroupToken { get; set; }
    }
}

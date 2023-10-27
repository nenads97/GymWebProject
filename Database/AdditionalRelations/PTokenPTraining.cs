using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class PTokenPTraining
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PTokenPTrainingId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("PersonalTraining")]
        public int PersonalTrainingId { get; set; }
        public PersonalTraining PersonalTraining { get; set; }

        [ForeignKey("PersonalToken")]
        public int PersonalTokenId { get; set; }
        public PersonalToken PersonalToken { get; set; }
    }
}

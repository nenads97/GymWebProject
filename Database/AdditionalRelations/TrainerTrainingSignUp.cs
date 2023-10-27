using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class TrainerTrainingSignUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTrenerTreningZakazivanje { get; set; }
        public DateTime DatumZakazivanja { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        [ForeignKey("Training")]
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}

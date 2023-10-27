using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class SignUpForTraining
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrijavljivanja { get; set; }
        public DateTime DatumIVremePrijavljivanja { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("SignUpForTraining")]
        public int SignUpId { get; set; }
        public virtual SignUpForTraining SignUp { get; set; }
    }
}

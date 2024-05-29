using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; set; }
        public bool Content { get; set; }
        public DateTime DateAndTime { get; set; } = DateTime.Now;

        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}

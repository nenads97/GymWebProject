using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class ClientRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientRequestId { get; set; }
        public DateTime DateTimeOfSubmission { get; set; } = DateTime.Now;

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public Request Request { get; set; }

        [ForeignKey("TrainerFK")]
        public int TrId { get; set; }
        public Trainer Trainer { get; set;}
    }
}

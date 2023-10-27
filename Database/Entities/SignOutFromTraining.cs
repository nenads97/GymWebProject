using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Database.Entities
{
    public class SignOutFromTraining
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SignOutId { get; set; }
        public DateTime DateTimeOfSignOut { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.AdditionalRelations;
using Database.Enums;

namespace Database.Entities
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public DateTime DateAndTimeOfRequestOpening { get; set; }
        public RequestStatus Status { get; set; }

        [ForeignKey("ClientRequest")]
        public int? ClientRequestId { get; set; }
        public virtual ClientRequest ClientRequest { get; set; }


        public int? ResponseId { get; set; }
        public virtual Response Response { get; set; }


        public int? PersonalTrainingId { get; set; }
        public virtual PersonalTraining PersonalTraining { get; set; }
    }
}

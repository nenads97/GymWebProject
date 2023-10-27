using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Membership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembershipId { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("PackageFK")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }

        [ForeignKey("ClientFK")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}

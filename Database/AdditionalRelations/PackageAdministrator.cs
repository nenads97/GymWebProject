using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class PackageAdministrator
    {
        public PackageAdministrator()
        {
            CreationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageAdministratorId { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("AdministratorFK")]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        [ForeignKey("PackageFK")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}

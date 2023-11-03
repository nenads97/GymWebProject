using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class PackagePrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackagePriceId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;


        [ForeignKey("Administrator")]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}

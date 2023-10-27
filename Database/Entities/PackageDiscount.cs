using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.JoinTables;

namespace Database.Entities
{
    public class PackageDiscount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageDiscountId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }

        [ForeignKey("AdministratorFK")]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<PackagePackageDiscount> PackagePackageDiscounts { get; set; }
    }
}

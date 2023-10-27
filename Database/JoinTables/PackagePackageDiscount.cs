using Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.JoinTables
{
    public class PackagePackageDiscount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackagePackageDiscountId { get; set; }

        [ForeignKey("PackageDiscountFK")]
        public int PackageDiscountId { get; set; }
        public PackageDiscount PackageDiscount { get; set; }

        [ForeignKey("PackageFK")]
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}

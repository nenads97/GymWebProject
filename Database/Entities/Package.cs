using Database.AdditionalRelations;
using Database.JoinTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        public string PackageName { get; set; }

        [ForeignKey("AdministratorFK")]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<PackageAdministrator> PackageAdministrators { get; set; }
        public virtual ICollection<PackagePackageDiscount> PackagePackageDiscounts { get; set; }
        public virtual ICollection<PackagePrice> PackagePrices { get; set; }
        //public virtual ICollection<TokenPackage> TokenPackages { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}

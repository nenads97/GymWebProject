using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class TokenPackage
    {
        public TokenPackage(int tokenPackageId, int quantity, int tokenId, int packageId)
        {
            TokenPackageId = tokenPackageId;
            Quantity = quantity;
            TokenId = tokenId;
            PackageId = packageId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenPackageId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Token")]
        public int TokenId { get; set; }
        public Token Token { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.AdditionalRelations;
using Database.Enums;

namespace Database.Entities
{
    public class Token
    {
        public Token(int tokenId, Category tokenType)
        {
            TokenId = tokenId;
            TokenType = tokenType;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenId { get; set; }
        public Category TokenType { get; set; }

        public virtual ICollection<TokenPrice> TokenPrices { get; set; }

        [ForeignKey("TokenPackage")]
        public int? TokenPackageId { get; set; }
        public virtual TokenPackage TokenPackage { get; set; }

        public virtual ICollection<TokenPurchase> TokenPurchases { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.AdditionalRelations;
using Database.Enums;

namespace Database.Entities
{
    public class Token
    {
        public Token()
        {
        }
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
        public virtual ICollection<TokenPackage> TokenPackages { get; set; }
        public virtual ICollection<TokenPurchase> TokenPurchases { get; set; }
    }
}

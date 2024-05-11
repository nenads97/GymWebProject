using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class TokenPrice
    {
        public TokenPrice(int tokenPriceId, double value, DateTime date, int administratorId, int tokenId)
        {
            TokenPriceId = tokenPriceId;
            Value = value;
            Date = date;
            AdministratorId = administratorId;
            TokenId = tokenId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenPriceId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Administrator")]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        [ForeignKey("Token")]
        public int TokenId { get; set; }
        public virtual Token Token { get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class TokenPrice
    {
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

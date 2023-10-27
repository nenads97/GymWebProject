using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Database.AdditionalRelations;

namespace Database.Entities
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKupovine { get; set; }
        public decimal Iznos { get; set; }
        public DateTime Datum { get; set; }

        public virtual ICollection<TokenPurchase> TokenPurchases { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}

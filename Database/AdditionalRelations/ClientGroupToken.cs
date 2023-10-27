using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class ClientGroupToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientGroupTokenId { get; set; }
        public int NumberOfGroupTokens { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("GroupToken")]
        public int GroupTokenId { get; set; }
        public virtual GroupToken GroupToken { get; set; }
    }
}

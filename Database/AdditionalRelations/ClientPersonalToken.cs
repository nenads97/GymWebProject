using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.AdditionalRelations
{
    public class ClientPersonalToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientPersonalTokenId { get; set; }
        public int NumberOfPersonalTokens { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("PersonalToken")]
        public int PersonalTokenId { get; set; }
        public virtual PersonalToken PersonalToken { get; set; }
    }
}

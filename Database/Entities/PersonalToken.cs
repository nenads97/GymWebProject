using Database.AdditionalRelations;
using Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class PersonalToken : Token
    {
        public PersonalToken(int tokenId, Category tokenType) : base(tokenId, tokenType) { }

        
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }

        public ICollection<ClientPersonalToken> ClientPersonalTokens { get; set; }

        /*
        [ForeignKey("PTokenPTraining")]
        public int? PTokenPTrainingId { get; set; }
        public PTokenPTraining PTokenPTraining { get; set; }
        */
    }
}

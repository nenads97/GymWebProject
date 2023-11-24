using Database.AdditionalRelations;
using Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class GroupToken : Token
    {
        public GroupToken(int tokenId, Category tokenType) : base(tokenId, tokenType)
        {
        }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }

        public ICollection<ClientGroupToken> ClientGroupTokens { get; set; }

        /*
        [ForeignKey("GroupTrainingFK")]
        public int? GTrainingGTokenId { get; set; }
        public GTokenGTraining GTokenGTraining { get; set; }
        */
    }
}

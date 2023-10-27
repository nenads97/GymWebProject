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

        [ForeignKey("ClientFK")]
        public int? ClientGroupTokenId { get; set; }
        public virtual ClientGroupToken ClientGroupToken { get; set; }

        [ForeignKey("GroupTrainingFK")]
        public int? GTrainingGTokenId { get; set; }
        public GTokenGTraining GTokenGTraining { get; set; }
    }
}

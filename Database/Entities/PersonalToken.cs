using Database.AdditionalRelations;
using Database.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class PersonalToken : Token
    {
        public PersonalToken(int tokenId, Category tokenType) : base(tokenId, tokenType) { }

        [ForeignKey("ClientPersonalToken")]
        public int? ClientPersonalTokenId { get; set; }
        public virtual ClientPersonalToken ClientPersonalToken { get; set; }

        [ForeignKey("PTokenPTraining")]
        public int? PTokenPTrainingId { get; set; }
        public PTokenPTraining PTokenPTraining { get; set; }
    }
}

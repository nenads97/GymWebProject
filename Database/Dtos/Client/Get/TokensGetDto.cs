using Database.Enums;

namespace Database.Dtos.Client.Get
{
    public class TokensGetDto
    {
        public int TokenId { get; set; }
        public Category TokenType { get; set; }
        public double TokenPriceValue { get; set; }
        public DateTime Date { get; set; }
    }
}

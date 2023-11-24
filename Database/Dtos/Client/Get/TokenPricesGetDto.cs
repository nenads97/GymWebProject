using Database.Enums;

namespace Database.Dtos.Client.Get
{
    public class TokenPricesGetDto
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Category TokenType { get; set; }
    }
}

namespace Database.Dtos.Admin
{
    public class TokenPriceCreateDto
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public int AdministratorId { get; set; }
        public int TokenId { get; set; }

    }
}

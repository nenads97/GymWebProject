namespace Database.Dtos.Client.Create
{
    public class PurchaseCreateDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
    }
}

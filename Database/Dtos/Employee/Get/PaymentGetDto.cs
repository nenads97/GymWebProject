namespace Database.Dtos.Employee.Get
{
    public class PaymentGetDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public long ClientJmbg { get; set; }
    }
}

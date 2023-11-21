namespace Database.Dtos.Employee.Create
{
    public class PaymentCreateDto
    {
        public decimal PaymentAmount { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
    }
}

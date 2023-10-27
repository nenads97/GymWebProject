namespace Database.Dtos.Admin.Create
{
    public class PackageDiscountCreateDto
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }
        public int AdministratorId { get; set; }
    }
}

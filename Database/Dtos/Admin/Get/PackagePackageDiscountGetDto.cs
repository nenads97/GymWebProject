namespace Database.Dtos.Admin.Get
{
    public class PackagePackageDiscountGetDto
    {
        public int PackageId { get; set; }
        public int PackageDiscountId { get; set; }
        public string PackageName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }
    }
}

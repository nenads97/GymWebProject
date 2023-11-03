namespace Database.Dtos.Admin.Create
{
    public class PackagePriceCreateDto
    {
        public double Value { get; set; }
        public int AdministratorId { get; set; }
        public int PackageId { get; set; }
    }
}

namespace Database.Dtos.Client.Get
{
    public class MembershipGetDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public DateTime JoiningDate { get; set; } 
        public DateTime ExpiryDate { get; set; }
    }
}

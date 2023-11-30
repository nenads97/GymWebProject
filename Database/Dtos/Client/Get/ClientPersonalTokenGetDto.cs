using Database.Enums;

namespace Database.Dtos.Client.Get
{
    public class ClientPersonalTokenGetDto
    {
        public int NumberOfPersonalTokens { get; set; }
        public int ClientId { get; set; }
        public int PersonalTokenId { get; set; }
    }
}

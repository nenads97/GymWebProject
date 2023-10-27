using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Dtos.Admin.Create
{
    public class PackageAdministratorCreateDto
    {
        public DateTime CreationDate { get; set; }
        public int AdministratorId { get; set; }
        public int PackageId { get; set; }
    }
}

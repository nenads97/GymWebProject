using Database.AdditionalRelations;
using Database.Data;
using Database.Enums;

namespace Database.Entities
{
    public class Administrator : Person
    {
        public Administrator(int id,long jMBG, double phoneNumber, string password, string username, Gender gender, string email, string surname, string firstname, Role role = Role.Administrator) : 
            base(id, jMBG, phoneNumber, password, username, gender, role, email, surname, firstname)
        {
        }

        public virtual ICollection<PackageAdministrator> PackageAdministrators { get; set; }
        public virtual ICollection<PackageDiscount> PackageDiscounts { get; set; }
        public virtual ICollection<PackagePrice> PackagePrices { get; set; }
        public virtual ICollection<TokenPrice> TokenPrices { get; set; }
    }
}

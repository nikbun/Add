using System.Data.Entity;

namespace AddressBook.Models
{
    public class AddressContext : DbContext
    {
        public AddressContext()
            : base("AddressBookDB")
        { }

        public DbSet<Address> AddressesDB { get; set; }
        public DbSet<TypeBuilding> TypeBuildDB { get; set; }
    }
}
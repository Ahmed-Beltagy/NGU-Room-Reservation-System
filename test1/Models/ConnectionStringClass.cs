using Microsoft.EntityFrameworkCore;


namespace test1.Models
{
    public class ConnectionStringClass:DbContext
    {
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options):base(options)
        {
            
        }
        public DbSet<Address> Rooms { get; set; }
    }
}

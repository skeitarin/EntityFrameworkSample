using System.Data.Entity;

namespace EFCodeFirst
{
    public class MyContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using api.Entities;
//Like Connector 
namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> users { get; set; } // users table name of the database
    }
}
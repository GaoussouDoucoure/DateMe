using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class DatingApplicationContext : DbContext
    {
        public DatingApplicationContext(DbContextOptions<DatingApplicationContext> options) : base (options) //Constructor 
        {
        }

        public DbSet<Application> Applications { get; set; } //this is what builds our table. 
        /* This line can be read as we are going to create a set of Application(.cs) and naming the table: Applications */
    }
}

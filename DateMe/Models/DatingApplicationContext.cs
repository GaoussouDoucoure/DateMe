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
        public DbSet<Major> Majors { get; set; }

        // this below will be populating the database (a.k.a. seed the database) putting our own initial values
        protected override void OnModelCreating(ModelBuilder modelBuilder)  //Seed data
        {
            modelBuilder.Entity<Major>().HasData(
                
                new Major { MajorId = 1, MajorName = "Information Systems" },
                new Major { MajorId = 2, MajorName = "Computer Science" },
                new Major { MajorId = 3, MajorName = "Magic" },
                new Major { MajorId = 4, MajorName = "Banana Stand" },
                new Major { MajorId = 5, MajorName = "Business Administration" }

                );
        }

    }
}

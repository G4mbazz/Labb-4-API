using API_Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4_API.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    PersonID = 1,
                    Name = "Mike Hawk",
                    PhoneNumber = "0705120743"
                });
            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    PersonID = 2,
                    Name = "Sara Andersson",
                    PhoneNumber = "0762958432"
                });
            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    PersonID = 3,
                    Name = "Kalle Skog",
                    PhoneNumber = "0735792358"
                });

            modelBuilder.Entity<Interests>()
                .HasData(new Interests
                {
                    ID = 1,
                    Title = "Programmera",
                    Description = "Skriva c# baserad kod för att skapa olika programm"
                });
            modelBuilder.Entity<Interests>()
                .HasData(new Interests
                {
                    ID = 2,
                    Title = "Musik",
                    Description = "Spela olika instrument och/eller sjunga"
                });
            modelBuilder.Entity<Interests>()
                .HasData(new Interests
                {
                    ID = 3,
                    Title = "Växter",
                    Description = "Att planera och odla olika former av växter"
                });
        }
    }
}

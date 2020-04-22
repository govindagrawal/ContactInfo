using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ContactInfo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Contact>()
                .Property(c => c.PhoneNumber)
                .IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(c => c.Address)
                .HasMaxLength(500);

            modelBuilder.Entity<Contact>()
                .Property(c => c.City)
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.State)
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Country)
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.PostCode)
                .HasMaxLength(10);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(10);

            base.OnModelCreating(modelBuilder);
        }
    }
}
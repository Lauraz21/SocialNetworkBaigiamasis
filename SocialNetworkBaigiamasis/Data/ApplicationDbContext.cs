using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetworkBaigiamasis.Models;

namespace SocialNetworkBaigiamasis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {  }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<User>()
                .HasOne(user => user.Person)
                .WithOne(personalInfo => personalInfo.User)
                .HasForeignKey<PersonalInfo>(personalInfo => personalInfo.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder
                .Entity<PersonalInfo>()
                .HasOne(personalInfo => personalInfo.Address)
                .WithOne(address => address.Person)
                .HasForeignKey<Address>(address => address.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
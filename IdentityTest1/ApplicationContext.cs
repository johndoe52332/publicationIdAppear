using IdentityTest1.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityTest1
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DbSet<Publication> Publications { get; set; }
        //public DbSet<Appli> MockUsers { get; set; }
        public DbSet<PublicationCategory> PublicationCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Identity */

            modelBuilder
                .Entity<ApplicationUser>()
                .ToTable("Users");

            modelBuilder
                .Entity<ApplicationRole>()
                .ToTable("Roles");

            modelBuilder
                .Entity<IdentityUserRole<Guid>>()
                .ToTable("UserRoles");

            modelBuilder
                .Entity<IdentityUserClaim<Guid>>()
                .ToTable("UserClaims");

            modelBuilder
                .Entity<IdentityUserLogin<Guid>>()
                .ToTable("UserLogins");

            modelBuilder
                .Entity<IdentityRoleClaim<Guid>>()
                .ToTable("RoleClaims");

            modelBuilder
                .Entity<IdentityUserToken<Guid>>()
                .ToTable("UserTokens"); // Guid

            /* Publication */

            modelBuilder
            .Entity<Publication>()
            .HasOne(_ => _.ApplicationUser)
            .WithMany()
            .HasForeignKey(_ => _.ApplicationUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
            .Entity<PublicationCategory>()
            .HasKey(_ => new { _.PublicationId, _.CategoryId });

            modelBuilder
            .Entity<PublicationCategory>()
            .HasOne(_ => _.Publication)
            .WithMany()
            .HasForeignKey(_ => _.PublicationId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

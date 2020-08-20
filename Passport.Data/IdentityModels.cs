﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Passport.Data.Entities;

namespace Passport.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RoadMap> RoadMap { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Stamp> Stamp { get; set; }
        public DbSet<Experience> Experience { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>()
                .Property(b => b._ChallengeScoreIncrease).HasColumnName("ChallengeScoreIncrease");
            modelBuilder.Entity<Experience>()
                .Property(b => b._RoadMaps).HasColumnName("RoadMaps");
            modelBuilder.Entity<Background>()
                .Property(b => b._AdventureLog).HasColumnName("SkillProficiencies");
            modelBuilder.Entity<RoadMap>()
            .Property(b => b._ChallengeScoreIncrease).HasColumnName("ChallengeScoreIncrease");
            modelBuilder.Entity<RoadMap>()
                .Property(b => b._Stamps).HasColumnName("Stamps");
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}
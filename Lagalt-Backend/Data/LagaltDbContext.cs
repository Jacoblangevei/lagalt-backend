using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Lagalt_Backend.Data.Models;

namespace Lagalt_Backend.Data
{
    public class LagaltDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=N-NO-01-01-5733\\SQLEXPRESS; Initial Catalog=LagaltEF; Integrated Security= true; Trust Server Certificate= true;");
            //Ida data source: N-NO-01-01-5733\SQLEXPRESS
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "UserNr1", Password = "Qwerty12345", Description = "I love coding", Education = "Coding Academy"}
                );

            //Projects
            modelBuilder.Entity<Project>().HasOne(p => p.Owner).WithMany(o => o.Projects).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.SetNull); //<--- What should happen to projects if a owner gets deleted?
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Happy Hacking", Description = "Hacking someone important", OwnerId = 1 }
                );

            //Owner
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, Username = "BestBoss", Password = "BestBoss123" }
                );

            
            //ProjectUser
            modelBuilder.Entity<ProjectUser>().HasKey(pu => new { pu.ProjectId, pu.UserId });

            modelBuilder.Entity<Project>()
                .HasMany(left => left.Users)
                .WithMany(right => right.Projects)
                .UsingEntity<ProjectUser>(
                    right => right.HasOne(e => e.Users).WithMany(),
                    left => left.HasOne(e => e.Projects).WithMany().HasForeignKey(e => e.ProjectId),
                    join => join.ToTable("ProjectUser")
                );

            modelBuilder.Entity<ProjectUser>().HasData(
                new ProjectUser() { ProjectId = 1, UserId = 1 }
                );
        }
    }
}

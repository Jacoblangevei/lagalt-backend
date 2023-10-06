﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data
{
    public class LagaltDbContext : DbContext
    {
        public LagaltDbContext(DbContextOptions<LagaltDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PortfolioProject> PortfolioProjects { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<MilestoneStatus> MilestoneStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=N-NO-01-01-5733\\SQLEXPRESS; Initial Catalog=LagaltEF; Integrated Security= true; Trust Server Certificate= true;");
            //Ida data source: N-NO-01-01-5733\SQLEXPRESS
        }*/

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

            //Skill
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1, SkillName = "Hacking"}
                );

            //SkillUser
            modelBuilder.Entity<SkillUser>().HasKey(su => new { su.SkillId, su.UserId });

            modelBuilder.Entity<Skill>()
                .HasMany(left => left.Users)
                .WithMany(right => right.Skills)
                .UsingEntity<SkillUser>(
                    right => right.HasOne(e => e.Users).WithMany(),
                    left => left.HasOne(e => e.Skills).WithMany().HasForeignKey(e => e.SkillId),
                    join => join.ToTable("SkillUser")
                );

            modelBuilder.Entity<SkillUser>().HasData(
                new SkillUser { SkillId = 1, UserId = 1 }
                );

            //PortfolioProject
            modelBuilder.Entity<PortfolioProject>().HasData(
                new PortfolioProject { PortfolioProjectId = 1, PortfolioProjectName = "Calculator", PortfolioProjectDescription = "Coded a simple calculator", StartDate = new DateTime(2000, 8, 23), EndDate = new DateTime(2001, 8, 23), ImageUrl = "calculator.no" }
                );

            //PortfolioProjectUser
            modelBuilder.Entity<PortfolioProjectUser>().HasKey(ppu => new { ppu.PortfolioProjectId, ppu.UserId });

            modelBuilder.Entity<PortfolioProject>()
                .HasMany(left => left.Users)
                .WithMany(right => right.PortfolioProjects)
                .UsingEntity<PortfolioProjectUser>(
                    right => right.HasOne(e => e.Users).WithMany(),
                    left => left.HasOne(e => e.PortfolioProjects).WithMany().HasForeignKey(e => e.PortfolioProjectId),
                    join => join.ToTable("PortfolioProjectUser")
                );

            modelBuilder.Entity<PortfolioProjectUser>().HasData(
                new PortfolioProjectUser { PortfolioProjectId = 1, UserId = 1 }
                );

            //Update
            modelBuilder.Entity<Update>().HasOne(ud => ud.User).WithMany(u => u.Updates).HasForeignKey(ud => ud.UserId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Update>().HasData(
                new Update { UpdateId = 1, UserId = 1, Description = "Fixed everything", Timestamp = DateTime.Now}
                );

            //ProjectUpdate
            modelBuilder.Entity<ProjectUpdate>().HasKey(pud => new { pud.ProjectId, pud.UpdateId });

            modelBuilder.Entity<Project>()
                .HasMany(left => left.Updates)
                .WithMany(right => right.Projects)
                .UsingEntity<ProjectUpdate>(
                    right => right.HasOne(e => e.Updates).WithMany(),
                    left => left.HasOne(e => e.Projects).WithMany().HasForeignKey(e => e.ProjectId),
                    join => join.ToTable("ProjectUpdate")
                );

            modelBuilder.Entity<ProjectUpdate>().HasData(
                new ProjectUpdate { ProjectId = 1, UpdateId = 1 }
                );

            //Milestone
            modelBuilder.Entity<Milestone>()
            .Property(m => m.PaymentAmount)
            .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Milestone>().HasOne(m => m.Project).WithMany(p => p.Milestones).HasForeignKey(m => m.ProjectId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Milestone>().HasOne(m => m.MilestoneStatus).WithMany(ms => ms.Milestones).HasForeignKey(m => m.MilestoneStatusId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Milestone>().HasData(
                new Milestone { MilestoneId = 1, Title = "Set up Azure", Description = "Set up Azure", DueDate = new DateTime(2023, 12, 01), Currency = "EUR", PaymentAmount = 10.99m, MilestoneStatusId = 1 }
                );

            //MilestoneStatus
            modelBuilder.Entity<MilestoneStatus>().HasData(
                new MilestoneStatus { MilestoneStatusId = 1, MilestoneStatusName = "Completed" }
                );

            //Tag
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1 , TagName = ".NET"}
                );

        }
    }
}
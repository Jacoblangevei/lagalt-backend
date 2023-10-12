using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System;

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
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<ProjectRequest> ProjectRequests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Requirement> Requirements { get; set; }

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
            modelBuilder.Entity<Project>().HasOne(p => p.ProjectStatus).WithMany(ps => ps.Projects).HasForeignKey(p => p.ProjectStatusId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Project>().HasOne(p => p.ProjectType).WithMany(pt => pt.Projects).HasForeignKey(p => p.ProjectTypeId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Happy Hacking", Description = "Hacking someone important", OwnerId = 1, ImageUrl = "www.example.no", ProjectTypeId = 10 },
                new Project { ProjectId = 2, Name = "Movie Maker", Description = "Make a cool movie", OwnerId = 1, ImageUrl= "www.example.no", ProjectTypeId = 4 }
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

            //ProjectStatus
            modelBuilder.Entity<ProjectStatus>().HasData(
                new ProjectStatus { StatusId = 1, StatusName = "Completed" }
                );

            //ProjectType
            modelBuilder.Entity<ProjectType>().HasData(
                new ProjectType { ProjectTypeId = 1, ProjectTypeName = "Software Development" },
                new ProjectType { ProjectTypeId = 2, ProjectTypeName = "Graphic Design"},
                new ProjectType { ProjectTypeId = 3, ProjectTypeName = "Game Development" },
                new ProjectType { ProjectTypeId = 4, ProjectTypeName = "Film Production" },
                new ProjectType { ProjectTypeId = 5, ProjectTypeName = "Music Production" },
                new ProjectType { ProjectTypeId = 6, ProjectTypeName = "Photography" },
                new ProjectType { ProjectTypeId = 7, ProjectTypeName = "Fashion Design" },
                new ProjectType { ProjectTypeId = 8, ProjectTypeName = "Interior Design" },
                new ProjectType { ProjectTypeId = 9, ProjectTypeName = "Research and Analysis" },
                new ProjectType { ProjectTypeId = 10, ProjectTypeName = "Hacking" }
                );

            //UserReview
            modelBuilder.Entity<UserReview>().HasOne(ur => ur.User).WithMany(u => u.UserReviews).HasForeignKey(ur => ur.UserId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<UserReview>().HasOne(ur => ur.Owner).WithMany(o => o.UserReviews).HasForeignKey(ur => ur.OwnerId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserReview>().HasData(
                new UserReview { UserReviewId = 1, UserId = 1, OwnerId = 1, Review = "Very good"},
                new UserReview { UserReviewId = 2, UserId = 1, OwnerId = 1, Review = "Did a very good job" }
                );

            //ProjectRequest
            modelBuilder.Entity<ProjectRequest>().HasOne(pr => pr.User).WithMany(u => u.ProjectRequests).HasForeignKey(pr => pr.UserId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ProjectRequest>().HasOne(pr => pr.Project).WithMany(p => p.ProjectRequests).HasForeignKey(pr => pr.ProjectId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProjectRequest>().HasData(
                new ProjectRequest { ProjectRequestId = 1, ProjectId = 2, UserId = 1, RequestDate = DateTime.Now}
                );

            //Messages
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.CreatorId)
                .HasConstraintName("FK_Message_User")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Owner)
                .WithMany()
                .HasForeignKey(m => m.CreatorId)
                .HasConstraintName("FK_Message_Owner")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<Message>().HasData(
                new Message { MessageId = 1, CreatorId = 1, CreatorType = "User", Subject = "Need link", MessageContent = "Hi, I need a link", Timestamp = DateTime.Now, ProjectId = 1},
                new Message { MessageId = 2, CreatorId = 1, CreatorType = "Owner", Subject = "How to do...", MessageContent = "Can someone explain how...", Timestamp = DateTime.Now, ProjectId = 1}
                );

            //Comments
            modelBuilder.Entity<Comment>().HasOne(c => c.Message).WithMany(m => m.Comments).HasForeignKey(c => c.MessageId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.CreatorId)
                .HasConstraintName("FK_Comment_User")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Owner)
                .WithMany()
                .HasForeignKey(c => c.CreatorId)
                .HasConstraintName("FK_Comment_Owner")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, CreatorId = 1, CreatorType = "User", CommentText = "I can help!", Timestamp = DateTime.Now, MessageId = 1},
                new Comment { CommentId = 2, CreatorId = 1, CreatorType = "Owner", CommentText = "This is cool", Timestamp = DateTime.Now, MessageId = 2}
                );

            //Project requirements
            modelBuilder.Entity<Requirement>()
                .HasOne(r => r.Project)
                .WithMany(p => p.Requirements)
                .HasForeignKey(r => r.ProjectId);

            modelBuilder.Entity<Requirement>().HasData(
                new Requirement { RequirementId = 1, RequirementText = "Experience with hacking", ProjectId = 1}
                );
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using System.Xml;

namespace Lagalt_Backend.Data
{
    public class LagaltDbContext : DbContext
    {
        public LagaltDbContext(DbContextOptions<LagaltDbContext> options) : base(options) 
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PortfolioProject> PortfolioProjects { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<MilestoneStatus> MilestoneStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectRequest> ProjectRequests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectRequirement> ProjectRequirements { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=N-NO-01-01-5733\\SQLEXPRESS; Initial Catalog=LagaltEF; Integrated Security= true; Trust Server Certificate= true;");
        //    //Ida data source: N-NO-01-01-5733\SQLEXPRESS
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = new Guid("00000000-0000-0000-0000-000000000001"), UserName = "UserNr1", Description = "I love coding", Education = "Coding Academy", AnonymousModeOn = false}
                );

            //Projects
            modelBuilder.Entity<Project>().HasOne(p => p.Owner).WithMany(u => u.ProjectsOwned).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.SetNull); //<--- What should happen to projects if a owner gets deleted?
            modelBuilder.Entity<Project>().HasOne(p => p.ProjectStatus).WithMany(ps => ps.Projects).HasForeignKey(p => p.ProjectStatusId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Project>().HasOne(p => p.ProjectType).WithMany(pt => pt.Projects).HasForeignKey(p => p.ProjectTypeId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Happy Hacking", Description = "Hacking someone important", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), ImageUrl = "www.example.no", ProjectTypeId = 10 },
                new Project { ProjectId = 2, Name = "Movie Maker", Description = "Make a cool movie", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), ImageUrl= "www.example.no", ProjectTypeId = 4 }
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
                new ProjectUser() { ProjectId = 1, UserId = new Guid("00000000-0000-0000-0000-000000000001"), Role = "Owner" },
                new ProjectUser() { ProjectId = 2, UserId = new Guid("00000000-0000-0000-0000-000000000001"), Role = "User"}
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
                new SkillUser { SkillId = 1, UserId = new Guid("00000000-0000-0000-0000-000000000001") }
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
                new PortfolioProjectUser { PortfolioProjectId = 1, UserId = new Guid("00000000-0000-0000-0000-000000000001") }
                );

            //Update
            modelBuilder.Entity<Update>().HasOne(ud => ud.User).WithMany(u => u.Updates).HasForeignKey(ud => ud.UserId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Update>().HasData(
                new Update { UpdateId = 1, UserId = new Guid("00000000-0000-0000-0000-000000000001"), Description = "Fixed everything", Timestamp = DateTime.Now}
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

            //ProjectTag
            modelBuilder.Entity<ProjectTag>().HasKey(pt => new { pt.ProjectId, pt.TagId });

            modelBuilder.Entity<Project>()
                .HasMany(left => left.Tags)
                .WithMany(right => right.Projects)
                .UsingEntity<ProjectTag>(
                    right => right.HasOne(e => e.Tags).WithMany(),
                    left => left.HasOne(e => e.Projects).WithMany().HasForeignKey(e => e.ProjectId),
                    join => join.ToTable("ProjectTag")
                );

            modelBuilder.Entity<ProjectTag>().HasData(
                new ProjectTag { ProjectId = 1, TagId = 1 }
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

            //ProjectRequest
            modelBuilder.Entity<ProjectRequest>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.ProjectRequests)
                .HasForeignKey(pr => pr.UserId);

            modelBuilder.Entity<ProjectRequest>()
                .HasOne(pr => pr.Project)
                .WithMany(p => p.ProjectRequests)
                .HasForeignKey(pr => pr.ProjectId);

            modelBuilder.Entity<ProjectRequest>().HasData(
                new ProjectRequest { ProjectRequestId = 1, ProjectId = 2, UserId = new Guid("00000000-0000-0000-0000-000000000001"), RequestDate = DateTime.Now}
                );

            //Messages
            modelBuilder.Entity<Message>()
                .HasMany(m => m.Replies)
                .WithOne(r => r.Parent)
                .HasForeignKey(r => r.ParentId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId)
                .IsRequired(false);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Project)
                .WithMany(p => p.Messages)
                .HasForeignKey(m => m.ProjectId)
                .IsRequired(false);

            modelBuilder.Entity<Message>().HasData(
                new Message { MessageId = 1, UserId = new Guid("00000000-0000-0000-0000-000000000001"), Subject = "Need link", MessageContent = "Hi, I need a link", ImageUrl="www.image.no", Timestamp = DateTime.Now, ProjectId = 1},
                new Message { MessageId = 2, UserId = new Guid("00000000-0000-0000-0000-000000000001"), Subject = "How to do...", MessageContent = "Can someone explain how...", ImageUrl = "www.image.no", Timestamp = DateTime.Now, ProjectId = 1}
                );

            //Requirements

            modelBuilder.Entity<Requirement>().HasData(
                new Requirement { RequirementId = 1, RequirementText = "Experience with hacking"}
                );

            //ProjectRequirements
            modelBuilder.Entity<ProjectRequirement>().HasKey(pr => new { pr.ProjectId, pr.RequirementId });

            modelBuilder.Entity<Project>()
                .HasMany(left => left.Requirements)
                .WithMany(right => right.Projects)
                .UsingEntity<ProjectRequirement>(
                    right => right.HasOne(e => e.Requirements).WithMany(),
                    left => left.HasOne(e => e.Projects).WithMany().HasForeignKey(e => e.ProjectId),
                    join => join.ToTable("ProjectRequirement")
                );

            modelBuilder.Entity<ProjectRequirement>().HasData(
                new ProjectRequirement { ProjectId = 1, RequirementId = 1 }
                );
        }
    }
}
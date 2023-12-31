﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data.Models.UserModels
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public Guid UserId { get; set; } // GUID
        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }
        public string? Education { get; set; }
        public bool AnonymousModeOn { get; set; }

        //Navigation
        public ICollection<Project> Projects { get; set; }
        public ICollection<Project> ProjectsOwned { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<PortfolioProject> PortfolioProjects { get; set; }
        public ICollection<Update> Updates { get; set; }
        //public ICollection<UserReview> UserReviews { get; set; }
        public ICollection<ProjectRequest> ProjectRequests { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}

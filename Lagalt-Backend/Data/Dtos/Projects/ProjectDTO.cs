using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Projects
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? OwnerId { get; set; }

        public int? ProjectStatusId { get; set; }
        public int? ProjectTypeId { get; set; }

        public int[] Users { get; set; }
        public int[] Updates { get; set; }
        public int[] Milestones { get; set; }
        public int[] Tags { get; set; }
        public int[] ProjectRequests { get; set; }
    }
}

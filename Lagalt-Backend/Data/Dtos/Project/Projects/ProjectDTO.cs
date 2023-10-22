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
        public string ImageUrl { get; set; }
        public Guid? OwnerId { get; set; }

        public int? ProjectStatusId { get; set; }
        public int? ProjectTypeId { get; set; }

        public Guid[] Users { get; set; }
        public int[] Updates { get; set; }
        public int[] Milestones { get; set; }
        public int[] Tags { get; set; }
        public int[] ProjectRequests { get; set; }
        public int[] Requirements { get; set; }
        public int[] Messages { get; set; }
        public int[] Resource {  get; set; }
    }
}

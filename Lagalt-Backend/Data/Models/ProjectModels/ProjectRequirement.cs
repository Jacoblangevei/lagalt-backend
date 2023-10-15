namespace Lagalt_Backend.Data.Models.ProjectModels
{
    public class ProjectRequirement
    {
        public int? ProjectId { get; set; }
        public Project? Projects { get; set; }
        public int? RequirementId { get; set; }
        public Requirement Requirements { get; set; }
    }
}

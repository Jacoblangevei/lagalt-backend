namespace Lagalt_Backend.Data.Models.ProjectModels
{
    public class ProjectUpdate
    {
        public int ProjectId { get; set; }
        public Project Projects { get; set; }
        public int UpdateId { get; set; }
        public Update Updates { get; set; }
    }
}

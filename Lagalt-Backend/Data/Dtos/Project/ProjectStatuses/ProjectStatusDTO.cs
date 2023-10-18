using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Project.ProjectStatuses
{
    public class ProjectStatusDTO
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int[] Projects { get; set; }
    }
}

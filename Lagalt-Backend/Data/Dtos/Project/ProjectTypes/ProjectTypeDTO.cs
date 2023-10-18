using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data.Dtos.ProjectTypes
{
    public class ProjectTypeDTO
    {
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public int[] Projects { get; set; }
    }
}

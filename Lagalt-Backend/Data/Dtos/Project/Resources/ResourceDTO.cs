using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Dtos.Project.Resources
{
    public class ResourceDTO
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceLink { get; set; }
        public int ProjectId { get; set; }
    }
}

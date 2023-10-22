using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(Resource))]
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceLink { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}

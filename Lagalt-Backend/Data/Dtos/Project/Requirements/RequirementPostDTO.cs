using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Requirements
{
    public class RequirementPostDTO
    {
        [Required]
        public string RequirementText { get; set; }
    }
}

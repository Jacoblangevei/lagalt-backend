using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Skills
{
    public class SkillPostDTO
    {
        [Required]
        public string SkillName { get; set; }
    }
}

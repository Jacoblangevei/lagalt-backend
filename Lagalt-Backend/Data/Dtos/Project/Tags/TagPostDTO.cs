using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Tags
{
    public class TagPostDTO
    {
        [Required]
        public string TagName { get; set; }
    }
}

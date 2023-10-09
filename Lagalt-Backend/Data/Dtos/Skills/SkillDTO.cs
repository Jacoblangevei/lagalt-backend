using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Skills
{
    public class SkillDTO
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int[] Users { get; set; }
    }
}

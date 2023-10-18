using Lagalt_Backend.Data.Models.ProjectModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Requirements
{
    public class RequirementDTO
    {
        public int RequirementId { get; set; }
        public string RequirementText { get; set; }
        public int[] Projects { get; set; }
    }
}

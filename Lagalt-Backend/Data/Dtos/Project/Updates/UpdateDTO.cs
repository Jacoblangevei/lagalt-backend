using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Project.Updates
{
    public class UpdateDTO
    {
        public int UpdateId { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid? UserId { get; set; }
        public int? ProjectId { get; set; }
    }
}

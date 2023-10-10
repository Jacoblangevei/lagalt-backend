using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Owners
{
    public class OwnerDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int[] Projects { get; set; }
        public int[] UserReviews { get; set; }
        public int[] Comments { get; set; }
        public int[] Messages { get; set; }
    }
}

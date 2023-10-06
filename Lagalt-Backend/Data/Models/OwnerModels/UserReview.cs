using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.OwnerModels
{
    [Table(nameof(UserReview))]
    public class UserReview
    {
        [Key]
        public int UserReviewId { get; set; }

        [Required]
        [StringLength(255)]
        public string Review { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}

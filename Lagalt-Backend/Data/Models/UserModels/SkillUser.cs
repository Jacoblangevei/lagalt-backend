namespace Lagalt_Backend.Data.Models.UserModels
{
    public class SkillUser
    {
        public int SkillId { get; set; }
        public Skill? Skills { get; set; }

        public int UserId { get; set; }
        public User? Users { get; set; }
    }
}

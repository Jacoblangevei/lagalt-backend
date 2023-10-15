namespace Lagalt_Backend.Data.Dtos.Tags
{
    public class TagDTO
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int[] Projects { get; set; }
    }
}

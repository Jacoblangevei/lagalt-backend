namespace Lagalt_Backend.Data.Models.MessageModels
{
    public class CommentMessage
    {
        public int? MessageId { get; set; }
        public Message? Messages { get; set; }
        public int? CommentId { get; set; }
        public Comment? Comments { get; set; }
    }
}

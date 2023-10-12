using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Services.Messages
{
    public interface IMessageService : ICrudService<Message, int> 
    {
        Task<ICollection<Comment>> GetAllCommentsInMessageAsync(int id);

        Task<Comment> GetCommentInMessageByIdAsync(int messageId, int commentId);

        Task<Comment> AddNewCommentToMessageAsync(int messageId, string commentText, int creatorId, string creatorRole);
    }
}

using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Services.Messages
{
    public interface IMessageService : ICrudService<Message, int> 
    {
        Task<ICollection<Comment>> GetAllCommentsInMessageAsync(int id);

        Task<Skill> GetCommentInMessageByIdAsync(int messageId, int commentId);

        Task AddNewCommentToMessageAsync(int messageId, string comment);
    }
}

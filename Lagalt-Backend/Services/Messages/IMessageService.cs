using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Services.Messages
{
    public interface IMessageService : ICrudService<Message, int> 
    {
        Task<Message> AddAsync(Message message);
        Task<Message> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<Message>> GetRepliesInMessageAsync(int messageId);
        Task<Message> GetReplyInMessageByIdAsync(int id, int replyId);
    }
}

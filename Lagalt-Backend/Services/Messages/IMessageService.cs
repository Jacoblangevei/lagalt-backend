using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;

namespace Lagalt_Backend.Services.Messages
{
    public interface IMessageService : ICrudService<Message, int> 
    {
        Task<ICollection<Comment>> GetAllCommentsInMessageAsync(int id);
    }
}

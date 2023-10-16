using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly LagaltDbContext _context;

        public MessageService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<Message> AddAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }
        public async Task<Message> GetByIdAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                throw new EntityNotFoundException(nameof(Message), id);
            }
            return message;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Message>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Message>> GetRepliesInMessageAsync(int id)
        {
            return await _context.Messages
                .Where(m => m.ParentId == id)
                .ToListAsync();
        }
        public async Task<Message> GetReplyInMessageByIdAsync(int id, int replyId)
        {
            return await _context.Messages
                .Where(m => m.MessageId == replyId && m.ParentId == id)
                .SingleOrDefaultAsync();
        }


        //Add reply to message

        //Helping methods
        private async Task<bool> MessageExistsAsync(int id)
        {
            return await _context.Messages.AnyAsync(m => m.MessageId == id);
        }
    }
}

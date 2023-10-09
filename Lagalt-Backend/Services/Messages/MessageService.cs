using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly LagaltDbContext _context;

        public MessageService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<Message> AddAsync(Message obj)
        {
            await _context.Messages.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await MessageExistsAsync(id))
                throw new EntityNotFoundException(nameof(Project), id);

            var msg = await _context.Messages
                .Where(m => m.MessageId == id)
                .FirstAsync();

            _context.Messages.Remove(msg);
            await _context.SaveChangesAsync();
        }

        //Comments
        public async Task<ICollection<Comment>> GetAllCommentsInMessageAsync(int id)
        {
            if (!await MessageExistsAsync(id))
                throw new EntityNotFoundException(nameof(Message), id);

            return await _context.Comments
                .Where(c => c.MessageId == id)
                .ToListAsync();
        }

        //Helping methods
        private async Task<bool> MessageExistsAsync(int id)
        {
            return await _context.Messages.AnyAsync(m => m.MessageId == id);
        }
    }
}

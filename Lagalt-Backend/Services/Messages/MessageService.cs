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

        public async Task<ICollection<Message>> GetAllAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            var msg = await _context.Messages.Where(m => m.MessageId == id).FirstAsync();

            if (msg is null)
                throw new EntityNotFoundException(nameof(msg), id);

            return msg;
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

        //Helping methods
        private async Task<bool> MessageExistsAsync(int id)
        {
            return await _context.Messages.AnyAsync(m => m.MessageId == id);
        }
    }
}

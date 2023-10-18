using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects.Messages
{
    public class MessageProjectService : IMessageProjectService
    {
        private readonly LagaltDbContext _context;

        public MessageProjectService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetAllMessagesInProjectAsync(int id)
        {
            var messages = await _context.Messages
            .Include(m => m.Replies)
            .Where(m => m.ProjectId == id && m.ParentId == null)
            .ToListAsync();

            return messages;
        }

        public async Task<Message> GetMessageInProjectByIdAsync(int id, int messageId)
        {
            var message = await _context.Messages
               .Include(m => m.Replies)
               .Where(m => m.ProjectId == id && m.MessageId == messageId)
               .SingleOrDefaultAsync();

            if (message == null)
            {
                throw new EntityNotFoundException(nameof(Message), messageId);
            }

            return message;
        }

        public async Task<Message> AddMessageToProjectAsync(int id, Message message)
        {
            message.ProjectId = id;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }
    }
}

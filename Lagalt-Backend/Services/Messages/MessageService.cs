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

        //Comments
        public async Task<ICollection<Comment>> GetAllCommentsInMessageAsync(int id)
        {
            if (!await MessageExistsAsync(id))
                throw new EntityNotFoundException(nameof(Message), id);

            return await _context.Comments
                .Where(c => c.MessageId == id)
                .ToListAsync();
        }

        public async Task<Comment> GetCommentInMessageByIdAsync(int messageId, int commentId)
        {
            var message = await _context.Messages
                .Include(m => m.Comments)
                .FirstOrDefaultAsync(m => m.MessageId == messageId);

            if (message == null)
            {
                throw new EntityNotFoundException(nameof(Message), messageId);
            }

            var comment = message.Comments.FirstOrDefault(c => c.CommentId == commentId);

            if (comment == null)
            {
                throw new EntityNotFoundException(nameof(Comment), commentId);
            }

            return comment;
        }

        public async Task AddNewCommentToMessageAsync(int messageId, string comment)
        {
            var message = await _context.Messages
                .Include(m => m.Comments)
                .FirstOrDefaultAsync(m => m.MessageId == messageId);

            if (message == null)
            {
                throw new EntityNotFoundException(nameof(Message), messageId);
            }

            var newComment = new Comment { CommentText = comment, Timestamp = DateTime.Now,  };
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();
            message.Comments.Add(newComment);

            await _context.SaveChangesAsync();
        }

        //Helping methods
        private async Task<bool> MessageExistsAsync(int id)
        {
            return await _context.Messages.AnyAsync(m => m.MessageId == id);
        }
    }
}

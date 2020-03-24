using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Commands.Comment;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly PitchContext _context;

        public CommentService(PitchContext context)
        {
            _context = context;
        }

        public async Task CreateCommentAsync(CreateCommentCommand command, Account account, Pitch pitch)
        {
            var comment = new Comment { Content = command.Content };
            account.Comments.Add(comment);
            pitch.Comments.Add(comment);

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Comment>> GetForCaptainAsync(int captainId)
        {
            return await Task.FromResult(_context.Comments.Where(x => x.Creator.Id == captainId).AsEnumerable());
        }

        public async Task<IEnumerable<Comment>> GetForPitchAsync(int pitchId)
        {
            return await Task.FromResult(_context.Comments.Where(x => x.Pitch.Id == pitchId).AsEnumerable());
        }
    }
}

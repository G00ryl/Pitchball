using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Commands.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentCommand command, Account account, Pitch pitch);
        Task<IEnumerable<Comment>> GetForPitchAsync(int pitchId);
        Task<IEnumerable<Comment>> GetForCaptainAsync(int captainId);
    }
}

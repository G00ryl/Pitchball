using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Commands.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IMessageService
    {
        Task CreateMessageAsync(CreateMessage command, Account account);
        Task<IEnumerable<Message>> GetMessagesAsync();    
    }
}

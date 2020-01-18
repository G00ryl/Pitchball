using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IMessageService
    {
        //Task AddMessageAsync(CreateMessage command );
        Task<IEnumerable<Message>> GetMessagesAsync();    
    }
}

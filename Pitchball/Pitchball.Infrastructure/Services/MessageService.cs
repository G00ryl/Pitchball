using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Message;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly PitchContext _context;

        public MessageService(PitchContext context)
        {
            _context = context;
        }

        //public async Task AddMessageAsync(CreateMessage command)
        //{
        //    var message = new ContactMessage(command.Content);
        //    await _context.SaveChangesAsync();
        //}
        public async Task<IEnumerable<Message>> GetMessagesAsync()
          => await Task.FromResult(_context.Messages.ToList());

    }
}

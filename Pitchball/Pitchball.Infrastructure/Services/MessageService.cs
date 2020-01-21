using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
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
        private IAccountService _accountService;

        public MessageService(PitchContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public async Task CreateMessageAsync(CreateMessage command,Account account)
        {
            var message = new Message { Content = command.Content };
           
            await _context.Messages.AddAsync(message);
            account.Messages.Add(message);

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Message>> GetMessagesAsync()
          => await Task.FromResult(_context.Messages.Include(x => x.Creator).ToList());
    }
}

using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IContactMessageService 
    {
        Task AddContactMessageAsync(CreateContactMessageCommand command);
        Task<IEnumerable<ContactMessage>> GetMessagessAsync();
    }
}

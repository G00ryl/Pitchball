using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.ViewModels.Messages
{
    public class MessagesViewModel
    {
        public IEnumerable<Message> Messages { get; protected set; }
        public CreateMessage NewMessage { get; set; }

        public MessagesViewModel() { }

        public MessagesViewModel(IEnumerable<Message> messages)
        {
            Messages = messages;
            NewMessage = new CreateMessage();
        }
    }
}

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
        public IEnumerable<Message> Messages { get;  }
        public CreateMessage NewMessage { get; set; }

        public MessagesViewModel() { }

    }
}

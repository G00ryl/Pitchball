﻿using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands;
using Pitchball.Infrastructure.Commands.Message;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Data.QueryExtenions;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly PitchContext _context;

        public ContactMessageService(PitchContext context)
        {
            _context = context;
        }

        public async Task AddContactMessageAsync(CreateContactMessageCommand command)
        {
            var contactmessage = new ContactMessage(command.Name, command.Email, command.Text);
            await _context.ContactMessages.AddAsync(contactmessage);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactMessage>> GetMessagesAsync()
            => await Task.FromResult(_context.ContactMessages.OrderByDescending(x => x.CreatedAt).AsEnumerable());
        public async Task<ContactMessage> GetContactMessage(int id)
        {
                var contactMessage = await _context.ContactMessages.SingleOrDefaultAsync();

                if (contactMessage == null)
                    throw new CorruptedOperationException("Pitch doesn't exist");

                return contactMessage;
            }

            public async Task DeleteContactMessageAsync(int id)
        {
            var contactmessage = await GetContactMessage(id);
            _context.Remove(contactmessage);
            await _context.SaveChangesAsync();
        }
    }
}


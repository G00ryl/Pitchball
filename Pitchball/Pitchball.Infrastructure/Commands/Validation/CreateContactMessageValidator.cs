﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pitchball.Infrastructure.Extensions;
using Pitchball.Infrastructure.Commands.Message;
using Pitchball.Infrastructure.Extensions;


namespace SimpleBlog.Commands.Validation.Message
{
    public static class CreateContactMessageValidator
    {
        private static Regex nameRegex = new Regex(MessageRegex.Name);
        private static Regex emailRegex = new Regex(MessageRegex.Email);
        private static Regex textRegex = new Regex(MessageRegex.Text);

        public static void CommandValidation(CreateContactMessageCommand command)
        {
            if (command.Name == null || command.Email == null || command.Text == null)
            {
                throw new InternalSystemException("Fields can't be empty!");
            }
            else if (!nameRegex.IsMatch(command.Name) || !emailRegex.IsMatch(command.Email) || !textRegex.IsMatch(command.Text))
            {
                throw new InternalSystemException("Please provide correct data!");
            }
        }
    }
}

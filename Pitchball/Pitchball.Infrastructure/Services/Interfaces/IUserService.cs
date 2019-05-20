using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(CreateAccount command);
        Task<User> GetAsync(int id);
    }
}

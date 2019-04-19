using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Commands.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> LoginAsync(LoginAccount command);
        Task<Account> GetAsync(int id);
        Task ChangePasswordAsync(int id, UpdateAccount command);
    }
}

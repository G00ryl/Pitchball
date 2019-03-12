using Pitchball.Infrastructure.Commands.Captain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface ICaptainService
    {
        Task AddWIthTeamAsync(CreateCaptainWithTeam command);
    }
}

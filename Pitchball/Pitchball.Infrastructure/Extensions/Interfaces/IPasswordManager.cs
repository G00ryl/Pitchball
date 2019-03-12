using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Infrastructure.Extensions.Interfaces
{
    public interface IPasswordManager
    {
        void CalculatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        void CalculatePasswordHash(string password, out byte[] passwordHash, byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}

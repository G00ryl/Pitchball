using Pitchball.Infrastructure.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Pitchball.Infrastructure.Extensions
{
    public class PasswordManager : IPasswordManager
    {
        /// <summary>
        /// Calculate password hash and salt for the first time.
        /// </summary>
        /// <param name="password">Password provided by the user.</param>
        /// <param name="passwordHash">Hash created for given password.</param>
        /// <param name="passwordSalt">Salt used to create the hash.</param>
        public void CalculatePasswordHash(string password, out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            var hmac512 = new HMACSHA512();
            passwordSalt = hmac512.Key;
            passwordHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Calculate password hash when the salt is already created.
        /// </summary>
        /// <param name="password">Password provided by the user.</param>
        /// <param name="passwordHash">Hash created for given password.</param>
        /// <param name="passwordSalt">Already created salt. Used to create hash for provided password.</param>
        public void CalculatePasswordHash(string password, out byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac512 = new HMACSHA512(passwordSalt);
            passwordHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Checks if the hash created for provided password is the same as the given hash.
        /// </summary>
        /// <param name="password">Password provied by the user.</param>
        /// <param name="passwordHash">Hash created by the calculate method.</param>
        /// <param name="passwordSalt">Salt used to create provided hash.</param>
        /// <returns></returns>
        public bool VerifyPasswordHash(string password, byte[] passwordHash,
            byte[] passwordSalt)
        {
            var hmac512 = new HMACSHA512(passwordSalt);
            var computedHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < passwordHash.Length; i++)
                if (computedHash[i] != passwordHash[i]) return false;
            return true;
        }
    }
}

using JudoSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JudoSystem.Helpers
{
    public static class StringHelper
    {
        public static string HashPassword(string passwordToHash)
        {
            MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] passwordinBytes = Encoding.ASCII.GetBytes(passwordToHash);
            byte[] password = hasher.ComputeHash(passwordinBytes);
            string hashedPassword = encoder.GetString(password);

            return hashedPassword;
        }
    }
}

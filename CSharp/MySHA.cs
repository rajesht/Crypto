using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Crypto
{
    class MySHA
    {
        public string CreateHash(string password)
        {
            UTF8Encoding wnc = new UTF8Encoding();
            byte[] PasswordBytes = wnc.GetBytes(password);
            SHA256 hasher = SHA256.Create();
            byte[] hashvalue = hasher.ComputeHash(PasswordBytes);
            string sha256hash = wnc.GetString(hashvalue);
            return sha256hash;
        }
    }
}

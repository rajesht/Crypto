using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Crypto
{
    class KeyGenerator
    {
        public string GenerateSalt(int length)
        {
            byte[] saltbytes = new byte[length];
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            csprng.GetBytes(saltbytes);
               UTF8Encoding wnc = new UTF8Encoding();
            string salt = wnc.GetString(saltbytes);

            return salt;
        }
        public byte[] GenerateKey(string password, string salt, int KeySize)
        {
            int NumOfIterations = 1000;
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] saltbytes = encoding.GetBytes(salt);
             Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, saltbytes, NumOfIterations);
             return key.GetBytes(KeySize);

        }
    }
}

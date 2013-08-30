using System.IO;
using System.Security.Cryptography;

namespace Crypto
{
    public class MyAES
    {
        public byte[] encrypt(string PlainText, byte[] key, byte[] IV)
        {
            byte[] encrypted;
            
            Aes enc = Aes.Create();
            enc.Key = key;
            enc.IV = IV;
            enc.BlockSize = 128;
            enc.Mode = CipherMode.CBC;
            enc.Padding = PaddingMode.PKCS7;
            ICryptoTransform encryptor = enc.CreateEncryptor(enc.Key, enc.IV);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(PlainText);
            encrypted = ms.ToArray();
            return encrypted;
            
        }

        public string decrypt(byte[] CipherText, byte[] key, byte[] IV)
        {
            string PlainText = null;
            Aes dec = Aes.Create();
            dec.Key = key;
            dec.IV = IV;
            dec.BlockSize = 128;
            dec.Mode = CipherMode.CBC;
            dec.Padding = PaddingMode.PKCS7;
            ICryptoTransform decryptor = dec.CreateDecryptor(dec.Key, dec.IV);
            MemoryStream ms = new MemoryStream(CipherText);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            PlainText = sr.ReadToEnd();


            return PlainText;
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Epons.Gateway.Helpers
{
    public static class Crypto
    {

        public static string Decrypt(string str)
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);

            csp.FromXmlString(ReadPrivateKey());

            byte[] bytes = Convert.FromBase64String(str);

            byte[] decodedBytes = csp.Decrypt(bytes, true);

            return Encoding.UTF8.GetString(decodedBytes);
        }

        public static string Encrypt(string str)
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);

            csp.FromXmlString(ReadPublicKey());

            byte[] bytes = Encoding.UTF8.GetBytes(str);

            byte[] encodedBytes = csp.Encrypt(bytes, true);

            return Convert.ToBase64String(encodedBytes);
        }

        private static string ReadPrivateKey()
        {
            return File.ReadAllText("C:\\Keys\\EPONS\\private.key");
        }

        private static string ReadPublicKey()
        {
            return File.ReadAllText("C:\\Keys\\EPONS\\public.key");
        }
    }
}

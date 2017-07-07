using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Epons.Domain.Helpers
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

        public static string GenerateJWT(string username)
        {
            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(signingCredentials);

            var payload = new JwtPayload
            {
                {"jti", Guid.NewGuid() },
                {"exp", now.AddDays(1)},
                {"iss", "epons-api"},
                {"iat", now},
                {"username", username }
            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }

        public static bool ValidateJWT(string jwt)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwt);

            return true;
        }

        public static string MD5Hex(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input ?? string.Empty));

            return BitConverter.ToString(bytes);
        }

        public static string SHA1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }

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

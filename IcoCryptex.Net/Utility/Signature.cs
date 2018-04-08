using System;
using System.Security.Cryptography;
using System.Text;

namespace IcoCryptex.Net.Utility
{
    public static class Signature
    {
        private static readonly Encoding Encoding = Encoding.UTF8;

        public static string Create(string apiSecret, string pathAndQuery)
        {
            pathAndQuery = pathAndQuery.ToLower();
            var secretBytes = Encoding.GetBytes(apiSecret);
            using (var crypt = new HMACSHA512(secretBytes))
            {
                var hash = crypt.ComputeHash(Encoding.GetBytes(pathAndQuery));
                return Convert.ToBase64String(hash);
            }
        }
    }
}

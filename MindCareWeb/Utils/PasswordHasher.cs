using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MindCareWeb.Utils
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            byte[] salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 10000, 256 / 8);
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(subkey);
        }

        public static bool Verify(string hashed, string password)
        {
            var parts = hashed?.Split(':', 2);
            if (parts == null || parts.Length != 2) return false;
            var salt = Convert.FromBase64String(parts[0]);
            var expected = Convert.FromBase64String(parts[1]);
            var actual = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 10000, 256 / 8);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
    }
}

using System.Security.Cryptography;

namespace OpsVision_Backend.Utilities
{
    
        public static class SecureKeyGenerator
        {
            public static string GenerateSecureKey(int length)
            {
                const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                char[] chars = new char[length];
                byte[] bytes = new byte[length * 4];

                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(bytes);
                }

                for (int i = 0; i < length; i++)
                {
                    uint value = BitConverter.ToUInt32(bytes, i * 4);
                    chars[i] = validChars[(int)(value % (uint)validChars.Length)];
                }

                return new string(chars);
            }
        }
    }


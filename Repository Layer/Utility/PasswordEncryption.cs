using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Utility
{
    public static class PasswordEncryption
    {
        // Hardcoded Encryption Key (must be 32 bytes for AES-256)
        private static readonly string EncryptionKey = "u8/JCVfB3Vv3JYbT7G9L7fQf+4k5J1PoW7S5OQ16j0I=";

        // Hardcoded IV (must be 16 bytes for AES)
        private static readonly byte[] IV = Convert.FromBase64String("1AEcb0Xu1b4o1Qe3A9MbQA==");

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(EncryptionKey);
                aesAlg.IV = IV; // Use the hardcoded IV

                aesAlg.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(EncryptionKey);
                aesAlg.IV = IV; // Use the hardcoded IV

                aesAlg.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

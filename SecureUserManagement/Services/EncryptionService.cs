using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Services
{
    public class EncryptionService
    {
        private readonly string key = "12345678901234567890123456789012"; // 32 chars key for AES

        public string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.GenerateIV();

            using MemoryStream ms = new MemoryStream();

            ms.Write(aes.IV, 0, aes.IV.Length);

            using CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter sw = new StreamWriter(cs);

            sw.Write(plainText);
            sw.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string encryptedText)
        {
            byte[] fullData = Convert.FromBase64String(encryptedText);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);

            byte[] iv = new byte[16];
            Array.Copy(fullData, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using MemoryStream ms = new MemoryStream(fullData, 16, fullData.Length - 16);
            using CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
    }
}
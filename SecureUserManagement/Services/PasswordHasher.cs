using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Services
{
    public class PasswordHasher
    {
        // This method converts plain password into SHA-256 hash
        public string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            return Convert.ToBase64String(hashBytes);
        }

        // This method checks plain password with stored hashed password
        public bool VerifyPassword(string password, string hashedPassword)
        {
            string newHash = HashPassword(password);

            return newHash == hashedPassword;
        }
    }
}
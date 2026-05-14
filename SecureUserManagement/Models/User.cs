namespace SecureUserManagement.Models
{
    public class User
    {
        // Username of user
        public string Username { get; set; }

        // Password after hashing
        public string HashedPassword { get; set; }

        // Encrypted sensitive data
        public string EncryptedDetails { get; set; }
    }
}
using SecureUserManagement.Models;

namespace SecureUserManagement.Services
{
    public class UserService
    {
        private readonly List<User> users = new List<User>();
        private readonly PasswordHasher passwordHasher = new PasswordHasher();
        private readonly EncryptionService encryptionService = new EncryptionService();
        private readonly LoggingService loggingService = new LoggingService();

        public bool Register(string username, string password, string details)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Username and password cannot be empty.");
                }

                if (users.Any(u => u.Username == username))
                {
                    throw new Exception("User already exists.");
                }

                User user = new User
                {
                    Username = username,
                    HashedPassword = passwordHasher.HashPassword(password),
                    EncryptedDetails = encryptionService.Encrypt(details)
                };

                users.Add(user);
                loggingService.LogInfo($"User registered successfully: {username}");

                return true;
            }
            catch (Exception ex)
            {
                loggingService.LogError("Registration failed", ex);
                return false;
            }
        }

        public bool Authenticate(string username, string password)
        {
            try
            {
                User? user = users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    throw new Exception("Invalid username or password.");
                }

                bool isValid = passwordHasher.VerifyPassword(password, user.HashedPassword);

                if (isValid)
                {
                    loggingService.LogInfo($"Login successful: {username}");
                    return true;
                }

                throw new Exception("Invalid username or password.");
            }
            catch (Exception ex)
            {
                loggingService.LogError("Login failed", ex);
                return false;
            }
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void Register_User_ReturnsTrue()
        {
            UserService userService = new UserService();

            bool result = userService.Register("Ashwin", "123", "Bihar");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Login_WithCorrectPassword_ReturnsTrue()
        {
            UserService userService = new UserService();

            userService.Register("Ashwin", "123", "Bihar");

            bool result = userService.Authenticate("Ashwin", "123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Login_WithWrongPassword_ReturnsFalse()
        {
            UserService userService = new UserService();

            userService.Register("Ashwin", "123", "Bihar");

            bool result = userService.Authenticate("Ashwin", "999");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Encryption_And_Decryption_Works()
        {
            EncryptionService encryptionService = new EncryptionService();

            string originalText = "Sensitive Data";

            string encrypted = encryptionService.Encrypt(originalText);

            string decrypted = encryptionService.Decrypt(encrypted);

            Assert.AreEqual(originalText, decrypted);
        }
    }
}
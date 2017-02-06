using System;
using System.Security.Cryptography;
using System.Text;
using ZindeBlog.Web.Infrastructure.Services.Abstract;

namespace ZindeBlog.Web.Infrastructure.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string CreateSalt()
        {
            var data = new byte[0x10];

            var cryptoServiceProvider = System.Security.Cryptography.RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordAsBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));

            }
        }
        public static string MD5(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            using (MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputData = Encoding.UTF8.GetBytes(input);
                byte[] computedData = md5.ComputeHash(inputData);

                return BitConverter.ToString(computedData).Replace("-", "");
            }
        }
    }
}

using SecureCientDataManagementAPI.Interfaces;
using System.Security.Cryptography;

namespace SecureCientDataManagementAPI.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly byte[] _key;

        public EncryptionService(IConfiguration configuration)
        {
            var keyBase64 = Environment.GetEnvironmentVariable("ENCRYPTION_KEY")
                ?? throw new InvalidOperationException("ENCRYPTION_KEY environment variable is missing.");

            _key = Convert.FromBase64String(keyBase64);
            if (_key.Length != 32)
                throw new ArgumentException("ENCRYPTION_KEY must be a valid base64-encoded 32-byte key for AES-256.");
        }

        public string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.GenerateIV();

            using var ms = new MemoryStream();
            ms.Write(aes.IV, 0, aes.IV.Length);

            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
                sw.Write(plainText);

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string encryptedText)
        {
            var bytes = Convert.FromBase64String(encryptedText);
            using var aes = Aes.Create();
            aes.Key = _key;

            var iv = new byte[16];
            Array.Copy(bytes, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using var ms = new MemoryStream(bytes, 16, bytes.Length - 16);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
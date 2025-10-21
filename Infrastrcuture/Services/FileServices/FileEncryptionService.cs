using Application.Commons;
using Application.Interfaces.FileServices;
using Domain.Entites.Files;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services.FileServices
{
    public class FileEncryptionService : IFileEncryptionService
    {
        // Encrypt ملف
        public async Task<EncryptedFileResult> EncryptAsync(Stream plainFile)
        {
            // توليد مفتاح AES-256
            byte[] dek = RandomNumberGenerator.GetBytes(32); // 256-bit key
            byte[] nonce = RandomNumberGenerator.GetBytes(12); // GCM nonce 12-byte

            using var plainMem = new MemoryStream();
            await plainFile.CopyToAsync(plainMem);
            byte[] plainBytes = plainMem.ToArray();

            byte[] cipher = new byte[plainBytes.Length];
            byte[] tag = new byte[16]; // 128-bit authentication tag

            using (var aes = new AesGcm(dek))
            {
                aes.Encrypt(nonce, plainBytes, cipher, tag);
            }

            // حساب الـ hash
            using var sha = SHA256.Create();
            string hash = Convert.ToBase64String(sha.ComputeHash(plainBytes));

            // ارجع النتيجة متوافقة مع FileEntity
            return new EncryptedFileResult(
                CipherData: cipher,
                Hash: hash,
                Nonce: nonce,
                Tag: tag,
                KeyRef: "LocalKey",        // بدل Key Vault، ممكن تحط identifier محلي
                WrappedDek: dek            // ممكن تخزن encrypted لاحقًا لو عايز أمان أعلى
            );
        }

        // Decrypt ملف
        public async Task<byte[]> DecryptAsync(byte[] cipherData, FileEntity file)
        {
            if (file.WrappedDek == null || file.WrappedDek.Length != 32)
                throw new CryptographicException("Invalid DEK.");

            byte[] plain = new byte[cipherData.Length];
            using (var aes = new AesGcm(file.WrappedDek))
            {
                aes.Decrypt(file.Nonce, cipherData, file.Tag, plain);
            }

            // Verify integrity
            using var sha = SHA256.Create();
            string currentHash = Convert.ToBase64String(sha.ComputeHash(plain));

            if (!string.Equals(currentHash, file.Hash, StringComparison.Ordinal))
                throw new CryptographicException("File integrity check failed.");

            return plain;
        }
    }
}

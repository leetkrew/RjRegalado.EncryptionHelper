using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace RjRegalado.EncryptionHelper
{
    public interface IAesOperation : IDisposable
    {
        string Key { get; set; }
        string EncryptedText { get; set; }
        string PlainText { get; set; }
        void Decrypt();
        void Encrypt();
        void ExecuteDecrypt(ref BackgroundWorker bg);
        void ExecuteDecrypt(string plainText, string passKey, ref BackgroundWorker bg);
        void ExecuteEncrypt(ref BackgroundWorker bg);
        void ExecuteEncrypt(string plainText, string passKey, ref BackgroundWorker bg);
    }

    public class AesOperation : IAesOperation
    {
        private readonly SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposedValue;
        
        public string Key { get; set; }
        public string EncryptedText { get; set; }
        public string PlainText { get; set; }

        public void Decrypt()
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(this.EncryptedText);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(this.Key);
                aes.IV = iv;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(buffer))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            this.PlainText = streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
        public void Encrypt()
        {
            var iv = new byte[16];
            byte[] array;

            using (var aes = Aes.Create())
            {
                try
                {
                    aes.Key = Encoding.UTF8.GetBytes(this.Key);
                }
                catch
                {
                    throw new Exception("Invalid AES Key format");
                }

                aes.IV = iv;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(this.PlainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            this.EncryptedText = Convert.ToBase64String(array);
        }
        
        public void ExecuteDecrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;
                
            Decrypt();
            bg.ReportProgress(100, this.PlainText.Trim());
        }
        
        public void ExecuteDecrypt(string plainText, string passKey, ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            this.PlainText = plainText;
            this.Key = passKey;

            bg.ReportProgress(0, this.EncryptedText);

            Decrypt();

            bg.ReportProgress(100, this.PlainText);
        }
        
        public void ExecuteEncrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;
            
            Encrypt();
            bg.ReportProgress(100, this.EncryptedText.Trim());
        }
        
        public void ExecuteEncrypt(string plainText, string passKey, ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            this.PlainText = plainText;
            this.Key = passKey;

            bg.ReportProgress(0, this.PlainText);

            Encrypt();
            bg.ReportProgress(100, this.EncryptedText);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                _safeHandle.Dispose();
            }

            this.EncryptedText = null;
            this.PlainText = null;
            _disposedValue = true;
        }
    }
}

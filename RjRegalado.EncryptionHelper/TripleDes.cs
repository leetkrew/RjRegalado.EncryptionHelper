using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace RjRegalado.EncryptionHelper
{
    public interface ITripleDes : IDisposable
    {
        string EncryptedText { get; set; }
        string Iv { get; set; }
        string Passkey { get; set; }
        string PlainText { get; set; }
        void Decrypt();

        void Encrypt();

        void ExecuteDecrypt(string plainText, string passKey, string iv, ref BackgroundWorker bg);

        void ExecuteDecrypt(ref BackgroundWorker bg);

        void ExecuteEncrypt(ref BackgroundWorker bg);
        void ExecuteEncrypt(string plainText, string passKey, string iv, ref BackgroundWorker bg);
    }

    /// <summary>
    /// Provides common methods for encrypting and decrypting plain text using triple des
    /// </summary>
    public class TripleDes : ITripleDes
    {
        private readonly SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposedValue;
        public string EncryptedText { get; set; }
        public string Iv { get; set; }
        public string Passkey { get; set; }
        public string PlainText { get; set; }

        /// <summary>
        /// Decrypts text using triple des algorithm
        /// </summary>
        public void Decrypt()
        {
            byte[] results;
            var utf8 = new UTF8Encoding();

            var hashProvider = new MD5CryptoServiceProvider();
            var tripDes = new TripleDESCryptoServiceProvider();

            var tDesKey = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(this.Passkey)); 

            tripDes.Key = tDesKey;
            tripDes.IV = utf8.GetBytes(this.Iv);
            tripDes.Mode = CipherMode.CBC;
            tripDes.Padding = PaddingMode.Zeros;
            
            var enc = tripDes.CreateDecryptor();
            var data = Convert.FromBase64String(this.EncryptedText);

            try
            {
                results = enc.TransformFinalBlock(data, 0, data.Length);
            }
            finally
            {
                tripDes.Clear();
                hashProvider.Clear();
            }

            this.PlainText = utf8.GetString(results);
        }

        /// <summary>
        /// Disposes the TripleDes instance
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// /Encrypts text using triple des algorithm
        /// </summary>
        /// <returns></returns>
        public void Encrypt()
        {
            byte[] results;
            var utf8 = new UTF8Encoding();

            var hashProvider = new MD5CryptoServiceProvider();
            var tripDes = new TripleDESCryptoServiceProvider();

            var tDesKey = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(this.Passkey)); 

            tripDes.Key = tDesKey;
            tripDes.IV = utf8.GetBytes(this.Iv);
            tripDes.Mode = CipherMode.CBC;
            tripDes.Padding = PaddingMode.Zeros;

            var enc = tripDes.CreateEncryptor();
            var data = utf8.GetBytes(this.PlainText);

            try
            {
                results = enc.TransformFinalBlock(data, 0, data.Length);
            }
            finally
            {
                tripDes.Clear();
                hashProvider.Clear();
            }
            this.EncryptedText = Convert.ToBase64String(results);
        }

        /// <summary>
        /// Decrypts text using triple des algorithm
        /// </summary>
        /// <param name="bg"></param>
        public void ExecuteDecrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            bg.ReportProgress(0, $"Encrypted Text: {this.EncryptedText}");
            Decrypt();
            bg.ReportProgress(0, $"Decrypted Text: {this.PlainText}");
        }

        /// <summary>
        /// Decrypts text using triple des algorithm
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="passKey"></param>
        /// <param name="iv"></param>
        /// <param name="bg"></param>
        public void ExecuteDecrypt(string plainText, string passKey, string iv, ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            this.PlainText = plainText;
            this.Passkey = passKey;
            this.Iv = iv;
            bg.ReportProgress(0, $"Encrypted Text: {this.EncryptedText}");
            Decrypt();
            bg.ReportProgress(0, $"Decrypted Text: {this.PlainText}");
        }

        /// <summary>
        /// Encrypts text using triple des algorithm
        /// </summary>
        /// <param name="bg"></param>
        public void ExecuteEncrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            bg.ReportProgress(0, $"Pain Text: {this.PlainText}");
            Encrypt();
            bg.ReportProgress(0, $"Encrypted Text: {this.EncryptedText}");
        }

        /// <summary>
        /// Encrypts text using triple des algorithm
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="passKey"></param>
        /// <param name="iv"></param>
        /// <param name="bg"></param>
        public void ExecuteEncrypt(string plainText, string passKey, string iv, ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            this.PlainText = plainText;
            this.Passkey = passKey;
            this.Iv = iv;
            bg.ReportProgress(0, $"Plain Text: {this.PlainText}");
            Encrypt();
            bg.ReportProgress(0, $"Encrypted Text: {this.EncryptedText}");
        }

        /// <summary>
        /// Disposes the TripleDes instance
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                _safeHandle.Dispose();
            }

            this.EncryptedText = null;
            this.Passkey = null;
            this.PlainText = null;
            _disposedValue = true;
        }
    }
}

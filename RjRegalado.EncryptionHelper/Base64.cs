using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace RjRegalado.EncryptionHelper
{
    public interface IBase64 : IDisposable
    {
        string EncryptedText { get; set; }
        
        string PlainText { get; set; }
        void Decrypt();
        void Encrypt();
        void ExecuteDecrypt(string plainText, string passKey, string iv, ref BackgroundWorker bg);
        void ExecuteDecrypt(ref BackgroundWorker bg);
        void ExecuteEncrypt(ref BackgroundWorker bg);
        void ExecuteEncrypt(string plainText, string passKey, string iv, ref BackgroundWorker bg);

    }

    public class Base64 : IBase64
    
    {
        private readonly SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposedValue;

        public string PlainText { get; set; }
        public string EncryptedText { get; set; }

        /// <summary>
        /// Decrypts text using triple des algorithm
        /// </summary>
        public void Decrypt()
        {
            var base64EncodedBytes = System.Convert.FromBase64String(this.EncryptedText);
            this.PlainText = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(this.PlainText);
            this.EncryptedText = System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decrypts text using triple des algorithm
        /// </summary>
        /// <param name="bg"></param>
        public void ExecuteDecrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            Decrypt();
            bg.ReportProgress(100, this.PlainText.Trim());
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
            bg.ReportProgress(0, this.EncryptedText);
            Decrypt();
            bg.ReportProgress(100, this.PlainText);
        }

        /// <summary>
        /// Encrypts text using triple des algorithm
        /// </summary>
        /// <param name="bg"></param>
        public void ExecuteEncrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            Encrypt();
            bg.ReportProgress(100, this.EncryptedText.Trim());
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
            bg.ReportProgress(0, this.PlainText);
            Encrypt();
            bg.ReportProgress(100, this.EncryptedText);
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
            this.PlainText = null;
            _disposedValue = true;
        }
    }
}

using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace RjRegalado.EncryptionHelper
{
    public interface IMd5HashOperation : IDisposable
    {
        string EncryptedText { get; set; }
        bool LoweCase { get; set; }
        string PlainText { get; set; }
        void Encrypt();

        void ExecuteEncrypt(ref BackgroundWorker bg);
    }

    public class Md5HashOperation : IMd5HashOperation
    {
        private bool _disposedValue;
        public string EncryptedText { get; set; }
        public bool LoweCase { get; set; }
        public string PlainText { get; set; }

        public Md5HashOperation()
        {
            this.LoweCase = false;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Encrypt()
        {
            using (var md5 = MD5.Create())
            {
                var byteHash = md5.ComputeHash(Encoding.UTF8.GetBytes(this.PlainText));
                this.EncryptedText = this.LoweCase ? BitConverter.ToString(byteHash).Replace("-", "").ToLower() : BitConverter.ToString(byteHash).Replace("-", "");
            }
        }

        public void ExecuteEncrypt(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            Encrypt();
            bg.ReportProgress(100, this.EncryptedText.Trim());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            this.PlainText = null;
            this.EncryptedText = null;
            _disposedValue = true;
        }
    }
}
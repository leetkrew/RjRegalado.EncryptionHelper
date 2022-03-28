using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace RjRegalado.EncryptionHelper
{
    public interface IMd5Hash : IDisposable
    {
        string PlainText { get; set; }
        string EncryptedText { get; set; }
        void ExecuteEncrypt(ref BackgroundWorker bg);
        void Encrypt();
    }

    public class Md5Hash : IMd5Hash
    {
        public string PlainText { get; set; }
        public string EncryptedText { get; set; }

        private bool _disposedValue;


        public void Encrypt()
        {
            using (var md5 = MD5.Create())
            {
                var byteHash = md5.ComputeHash(Encoding.UTF8.GetBytes(this.PlainText));
                this.EncryptedText = BitConverter.ToString(byteHash).Replace("-", "");
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

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
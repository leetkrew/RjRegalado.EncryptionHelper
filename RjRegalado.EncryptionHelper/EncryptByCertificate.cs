using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RjRegalado.EncryptionHelper
{

    /*
        References:
            https://www.scottbrady91.com/openssl/creating-rsa-keys-using-openssl
            https://www.ibm.com/docs/en/arl/9.7?topic=certification-extracting-certificate-keys-from-pfx-file        

        Generate Certificates
            openssl genrsa -out private-key.pem 3072
            openssl req -new -x509 -key private-key.pem -out cert.pem -days 7300
            openssl pkcs12 -export -inkey private-key.pem -in cert.pem -out cert.pfx
            openssl pkcs12 -in cert.pfx -clcerts -nokeys -out public.crt
        
    */

    public interface IEncryptByCertificate : IDisposable
    {
        string Passkey { get; set; }
        string PlainText { get; set; }
        string PrivateKey { get; set; }
        string PublicKey { get; set; }
        void Decrypt();
        void Execute(ref BackgroundWorker bg);
        void Execute(string plainText, string publicKey, string privateKey, string passKey, ref BackgroundWorker bg);
        void Encrypt();
    }

    /// <summary>
    /// Provides common methods for encrypting and decrypting plain text using public and private keys
    /// </summary>
    public class EncryptByCertificate : IEncryptByCertificate
    {
        private readonly SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposedValue;
        public string EncryptedText { get; set; }
        public string Passkey { get; set; }
        public string PlainText { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }

        /// <summary>
        /// Decrypts text using a private key
        /// </summary>
        /// <returns></returns>
        public void Decrypt()
        {
            var collection = new X509Certificate2Collection();
            collection.Import(this.PrivateKey, this.Passkey, X509KeyStorageFlags.PersistKeySet);
            var certificate = collection[0];

            var privateKey = certificate.PrivateKey as RSACryptoServiceProvider;
            var bytesData = Convert.FromBase64String(this.EncryptedText);

            if (privateKey == null) this.PlainText = "error";
            if (privateKey == null) return;
            var dataByte = privateKey.Decrypt(bytesData, false);
            var b64Str = Convert.ToBase64String(dataByte);

            this.PlainText = Encoding.UTF8.GetString(dataByte);
        }

        /// <summary>
        /// Demonstration of EncryptByCertificate
        /// </summary>
        /// <param name="bg"></param>
        public void Execute(ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            Encrypt();
            bg.ReportProgress(0, $"Encrypted Text: {this.EncryptedText}");

            if (bg.CancellationPending) return;
            if (this.EncryptedText == null) return;

            Decrypt();
            bg.ReportProgress(0, $"Decrypted Text: {this.PlainText}");
        }

        /// <summary>
        /// Demonstration of EncryptByCertificate
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <param name="passKey"></param>
        /// <param name="bg"></param>
        public void Execute(string plainText, string publicKey, string privateKey, string passKey, ref BackgroundWorker bg)
        {
            if (bg.CancellationPending) return;

            this.PlainText = plainText;
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;
            this.Passkey = passKey;

            Encrypt();
            bg.ReportProgress(0, $"Encrypted Text: {this.EncryptedText}");

            if (bg.CancellationPending) return;
            if (this.EncryptedText == null) return;

            Decrypt();
            bg.ReportProgress(0, $"Decrypted Text: {this.PlainText}");
        }

        /// <summary>
        /// Disposes the EncryptByCertificate instance
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// /Encrypts text using a public key
        /// </summary>
        /// <returns></returns>
        public void Encrypt()
        {

            var collection = new X509Certificate2Collection();
            collection.Import(this.PublicKey, this.Passkey, X509KeyStorageFlags.PersistKeySet);
            var certificate = collection[0];
            var publicKey = certificate.PublicKey.Key as RSACryptoServiceProvider;
            var bytesData = Encoding.UTF8.GetBytes(this.PlainText);

            if (publicKey == null) this.EncryptedText = "error";
            if (publicKey == null) return;
            var encryptedData = publicKey.Encrypt(bytesData, false);
            var cypherText = Convert.ToBase64String(encryptedData);

            this.EncryptedText = cypherText;
        }

        /// <summary>
        /// Disposes the EncryptByCertificate instance
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
            this.PrivateKey = null;
            this.PublicKey = null;
            _disposedValue = true;
        }
    }
}

Encryption and Decryption using C#

EncryptionHelper is a library that provides an interface to encrypt and decrypt plain text. Written by a Filipino developer, RJ Regalado (www.rjregalado.com).

March 28, 2022
- Added Base64 encode and decode
- Added MD5
- UI improvements (but still ugly)

March 19, 2022

- Encryption and decryption of plain text using PFX certificate as a private key, and CRT certificate as a public key. Both keys allow the user to encrypt plain text. As designed, only the private key has the capability to decrypt an encrypted text.
- Implementation of System.Security.Cryptography and System.Security.Cryptography.X509Certificates.
- Use this commands to generate your own certificate

            openssl genrsa -out private-key.pem 3072
            
            openssl req -new -x509 -key private-key.pem -out cert.pem -days 7300
            
            openssl pkcs12 -export -inkey private-key.pem -in cert.pem -out cert.pfx
            
            openssl pkcs12 -in cert.pfx -clcerts -nokeys -out public.crt



More encryption and decryption methods to come.

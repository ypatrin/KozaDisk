﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KozaDisk.Class
{
    class CryptAes
    {
        public static string Encrypt(string plainText, string key)
        {
            string cipherText;
            var rijndael = new RijndaelManaged()
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                BlockSize = 128,
                Padding = PaddingMode.Zeros,
            };
            ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, null);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                        streamWriter.Flush();
                    }
                    //cipherText = Convert.ToBase64String(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(memoryStream.ToArray())));
                    cipherText = Convert.ToBase64String(memoryStream.ToArray());
                    //cryptoStream.FlushFinalBlock();
                }
            }
            return cipherText;
        }


        public static string Decrypt(string cipherText, string key)
        {
            string plainText;
            byte[] cipherArray = Convert.FromBase64String(cipherText);
            var rijndael = new RijndaelManaged()
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                BlockSize = 128,
                Padding = PaddingMode.Zeros,
            };
            ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

            using (var memoryStream = new MemoryStream(cipherArray))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        plainText = streamReader.ReadToEnd();
                    }
                }
            }
            return plainText;
        }

        /*
        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// DecryptStringAES().  The sharedSecret parameters must match.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="key">A key for encryption.</param>
        public static string EncryptStringAES(string plainText, string key)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                if (key.Length > 16)
                {
                    // Cut of the end if it exceeds 16 characters
                    key = key.Substring(0, 16);
                }
                else
                {
                    // Append zero to make it 16 characters if the provided key is less
                    while (key.Length < 16)
                    {
                        key += "0";
                    }
                }

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.BlockSize = 128;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.Key = Encoding.ASCII.GetBytes(key);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // prepend the IV
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// EncryptStringAES(), using an identical sharedSecret.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="key">A key for decryption.</param>
        public static string DecryptStringAES(string cipherText, string key)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                if (key.Length > 16)
                {
                    // Cut of the end if it exceeds 16 characters
                    key = key.Substring(0, 16);
                }
                else
                {
                    // Append zero to make it 16 characters if the provided key is less
                    while (key.Length < 16)
                    {
                        key += "0";
                    }
                }

                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Key = Encoding.ASCII.GetBytes(key);
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }
        */
    }
}
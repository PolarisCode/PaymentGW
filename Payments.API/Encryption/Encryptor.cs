using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Payments.API.Encryption
{
    /// <summary>
    /// Encryptor for card related information.
    /// </summary>
    public class Encryptor : IEncryptor
    {
        // static key is used for now but better add dynamic salt
        private readonly string key = "06984c5aa78022d573a8b7051ebb5f22";

        public string Decrypt(string encryptedSring)
        {
            RijndaelManaged algo = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 0x80,
                BlockSize = 0x80
            };

            byte[] encryptedTextByte = Convert.FromBase64String(encryptedSring);
            byte[] passBytes = Encoding.UTF8.GetBytes(key);
            byte[] EncryptionkeyBytes = new byte[0x10];

            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }

            Array.Copy(passBytes, EncryptionkeyBytes, len);

            algo.Key = EncryptionkeyBytes;
            algo.IV = EncryptionkeyBytes;

            byte[] textByte = algo.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);

            return Encoding.UTF8.GetString(textByte);  //it will return readable string
        }

        public string Encrypt(string pureText)
        {
            RijndaelManaged algo = new RijndaelManaged
            {
                //set the mode for operation of the algorithm
                Mode = CipherMode.CBC,
                //set the padding mode used in the algorithm.
                Padding = PaddingMode.PKCS7,
                //set the size, in bits, for the secret key.
                KeySize = 0x80,
                //set the block size in bits for the cryptographic operation.
                BlockSize = 0x80
            };

            //set the symmetric key that is used for encryption & decryption.
            byte[] passBytes = Encoding.UTF8.GetBytes(key);
            
            //set the initialization vector (IV) for the symmetric algorithm
            byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }

            Array.Copy(passBytes, EncryptionkeyBytes, len);

            algo.Key = EncryptionkeyBytes;
            algo.IV = EncryptionkeyBytes;
            
            //Creates symmetric AES object with the current key and initialization vector IV.
            ICryptoTransform objtransform = algo.CreateEncryptor();

            byte[] textDataByte = Encoding.UTF8.GetBytes(pureText);
           
            //Final transform the test string.
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }
    }
}

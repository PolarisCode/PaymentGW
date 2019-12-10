namespace Payments.API.Encryption
{
    public interface IEncryptor
    {
        string Encrypt(string clearString);
        string Decrypt(string encryptedSring);
    }
}

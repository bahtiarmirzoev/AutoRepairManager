using System.Security.Cryptography;
using System.Text;

namespace AutoRepairManagerApp.Infrastructure.Services;
public class GuidEncryptor
{
   
    private static string key = "1234567890abcdef";
    private static string iv = "abcdef9876543210"; 

    public static string EncryptGuid(Guid guid)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);   

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] guidBytes = Encoding.UTF8.GetBytes(guid.ToString());
            byte[] encrypted = encryptor.TransformFinalBlock(guidBytes, 0, guidBytes.Length);
            return Convert.ToBase64String(encrypted);
        }
    }

    public static Guid DecryptGuid(string encryptedGuid)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(key); 
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);   

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedGuid);
            byte[] decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            string decryptedGuidString = Encoding.UTF8.GetString(decrypted);
            return Guid.Parse(decryptedGuidString);
        }
    }
}

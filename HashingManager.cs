using System.Security.Cryptography;

namespace Instagram_Clone_Backend;

public class HashingManager
{
    private const int SaltSize = 16;

    public static byte[] GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    public static string HashPassword(string password, byte[] salt)
    {
        using (var sha256Hash = SHA256.Create())
        {
            byte[] passwordWithSalt = ConcatenateByteArrays(System.Text.Encoding.UTF8.GetBytes(password), salt);
            byte[] hashBytes = sha256Hash.ComputeHash(passwordWithSalt);
            string hash = Convert.ToBase64String(hashBytes);
            return hash + ":" + Convert.ToBase64String(salt);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        string[] parts = hashedPassword.Split(':');
        byte[] hashBytes = Convert.FromBase64String(parts[0]);
        byte[] salt = Convert.FromBase64String(parts[1]);
        byte[] passwordWithSalt = ConcatenateByteArrays(System.Text.Encoding.UTF8.GetBytes(password), salt);
        using (var sha256Hash = SHA256.Create())
        {
            byte[] computedHashBytes = sha256Hash.ComputeHash(passwordWithSalt);
            return computedHashBytes.SequenceEqual(hashBytes);
        }
    }

    private static byte[] ConcatenateByteArrays(byte[] first, byte[] second)
    {
        byte[] result = new byte[first.Length + second.Length];
        Array.Copy(first, result, first.Length);
        Array.Copy(second, 0, result, first.Length, second.Length);
        return result;
    }
}

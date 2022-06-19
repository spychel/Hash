using System.Security.Cryptography;
static class Hash
{
    static byte[] MakeSalt()
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        return salt;
    }

    public static byte[] GetSalt(string passwordHash)
    {
        byte[] hashBytes = Convert.FromBase64String(passwordHash);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
        return salt;
    }

    public static byte[] MakeHash(byte[] salt, string password)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
        return pbkdf2.GetBytes(20);
    }

    public static byte[] GetHash(string passwordHash)
    {
        byte[] hashBytes = Convert.FromBase64String(passwordHash);
        byte[] hash = new byte[20];
        Array.Copy(hashBytes, 16, hash, 0, 20);
        return hash;
    }

    static byte[] GetHashBytes(byte[] salt, byte[] hash)
    {
        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);
        return hashBytes;
    }
    
    public static string CreatePasswordHash(string password)
    {
        var salt = MakeSalt();
        var hash = MakeHash(salt, password);
        var hashBytes = GetHashBytes(salt, hash);

        return Convert.ToBase64String(hashBytes);
    }
}
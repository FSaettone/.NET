using System;
using System.Security.Cryptography;
using System.Text;

namespace SGI.Aplicacion;

public static class HashHelper
{

    public static string GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }

    public static string HashPassword(string password, string salt)
    {
        using(var sha256 = SHA256.Create())
        {
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha256.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hash);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword, string salt)
    {
        string hashed = HashPassword(password, salt);
        return hashed == hashedPassword;
    }

}

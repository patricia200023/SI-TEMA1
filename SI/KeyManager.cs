using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

class KeyManager
{
    public KeyManager()
    {
        this.K1 = this.GenerateRandomString();
        this.K2 = "1234567812345678";
    }

    public string EncryptKey()
    {
       return Utils.Encrypt(this.K2, this.K1);
    }

    public string GenerateRandomString()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 16)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    public string K1 { get; set; } // K
    public string K2 { get; set; } // K'
}
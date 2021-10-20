using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class CFBMode : OperationMode
{
    const string IV = "ABCDEFGHJKLMNOPQ";
    override public void Encrypt(string block, string key)
    {
        var blockEncrypted = " ";
        if (Blocks.Count == 0)
        {
            blockEncrypted = Utils.Encrypt(key, IV);
        }
        else
        {
            blockEncrypted = Utils.Encrypt(key, Blocks[Blocks.Count - 1]);
        }
        Blocks.Add(this.XOR(block, blockEncrypted));
    }

    override public void Decrypt(string block, string key)
    {
     
        var blockDecrypted = " ";
        if (EncryptedBlocks.Count == 0)
        {
            blockDecrypted = Utils.Encrypt(key, IV);
        }
        else
        { 
            blockDecrypted = Utils.Encrypt(key, Blocks[Blocks.Count - 2]);
        }
        EncryptedBlocks.Add(this.XOR(block, blockDecrypted));
    }

    private string XOR(string plaintext, string pad)
    {
        StringBuilder cyphertext = new StringBuilder(plaintext.Length);

        for (int i = 0; i < plaintext.Length; ++i)
            cyphertext.Append((char)(plaintext[i] ^ pad[i % pad.Length]));

        return cyphertext.ToString();
    }

    public static List<string> Blocks { get; set; }
    public static List<string> EncryptedBlocks { get; set; }
}
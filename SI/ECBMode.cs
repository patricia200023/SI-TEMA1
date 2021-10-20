using System;
using System.Collections.Generic;

class ECBMode : OperationMode
{
    override public void Encrypt(string block, string key)
    {
        Blocks.Add(Utils.Encrypt(key, block));
    }

    override public void Decrypt(string block, string key)
    {
        EncryptedBlocks.Add(Utils.Decrypt(key, block));
    }

    public static List<string> Blocks { get; set; }
    public static List<string> EncryptedBlocks { get; set; }
}
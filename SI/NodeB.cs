using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class NodeB : Node
{
    public NodeB(KeyManager keyManager) : base(keyManager) { }
    override public void AskForEncryptionKey(string key)
    {
        this.EncryptionKey = key;
        this.DecryptionKey = this.DecryptKey(this.EncryptionKey);
        Console.WriteLine($"Node B encryption key: {this.EncryptionKey}");
        Console.WriteLine($"Node B decrypted key: {this.DecryptionKey}");
    }

    public void SetOperationMode(Mode operationMode)
    {
        this.OperationMode = operationMode;
        this.NotifyNodeA();
    }

    private void NotifyNodeA()
    {
        Console.WriteLine("Node B: Start encryption!");
        string fileContent = File.ReadAllText("/home/patricia/file.txt");
        Console.WriteLine(fileContent);
        if (this.OperationMode == Mode.ECB)
        {
            var ECB = new ECBMode();
            ECBMode.Blocks = new List<string>();
            ECBMode.EncryptedBlocks = new List<string>();
            for (int index = 0; index < fileContent.Length % 16; index++)
            {
                fileContent = String.Concat(fileContent, " ");
            }
            for (int index = 0; index < fileContent.Length / 16; index++)
            {
               ECB.Encrypt(fileContent.Substring(index * 16, 16), this.DecryptionKey);
               ECB.Decrypt(ECBMode.Blocks[index], this.DecryptionKey);
            }
            Console.WriteLine("ECB text encrypted: ");
            ECBMode.Blocks.ForEach(item => {
                Console.WriteLine(item);
            });
            Console.WriteLine("ECB text decrypted: ");
            ECBMode.EncryptedBlocks.ForEach(item => {
                Console.WriteLine(item);
            });
        }
        else
        {
            var CFB = new CFBMode();
            CFBMode.Blocks = new List<string>();
            CFBMode.EncryptedBlocks = new List<string>();
            for (int index = 0; index < fileContent.Length % 16; index++)
            {
                fileContent = String.Concat(fileContent, " ");
            }
            for (int index = 0; index < fileContent.Length / 16; index++)
            {
               CFB.Encrypt(fileContent.Substring(index * 16, 16), this.DecryptionKey);
               CFB.Decrypt(CFBMode.Blocks[index], this.DecryptionKey);
            }
            Console.WriteLine("CFB text encrypted: ");
            CFBMode.Blocks.ForEach(item => {
                Console.WriteLine(item);
            });
            Console.WriteLine("CFB text decrypted: ");
            CFBMode.EncryptedBlocks.ForEach(item => {
                Console.WriteLine(item);
            });
        }
    }
}

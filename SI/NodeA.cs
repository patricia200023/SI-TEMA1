using System;
class NodeA : Node
{
    public NodeA(KeyManager keyManager) : base(keyManager) {}
    override public void AskForEncryptionKey(string key)
    {
        this.EncryptionKey = key;
        this.DecryptionKey = this.DecryptKey(this.EncryptionKey);
        Console.WriteLine($"Node A encryption key: {this.EncryptionKey}");
        Console.WriteLine($"Node A decrypted key: {this.DecryptionKey}");
        this.GetOperationMode();
    }

    private void GetOperationMode()
    {
        Console.WriteLine("Please choose an operation mode {ECB, CFB}!");
        this.OperationMode = Console.ReadLine() == "ECB" ? Mode.ECB : Mode.CFB;
        Console.WriteLine($"You've choosen {this.OperationMode.ToString()} operation mode!");
    }
}

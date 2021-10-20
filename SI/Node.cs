using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

abstract class Node
{
    public Node() { }
    public Node(KeyManager keyManager)
    {
        KeyManager = keyManager;
    }

    public abstract void AskForEncryptionKey(string key);
    public string DecryptKey(string text)
    {
        return Utils.Decrypt(KeyManager.K2, text);
    }
    public static KeyManager KeyManager { get; set; }
    public string EncryptionKey { get; set; }
    public string DecryptionKey { get; set; }
    public Mode OperationMode { get; set; }
}
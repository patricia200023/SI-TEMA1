using System;

namespace SI
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyManager = new KeyManager();
            Console.WriteLine($"Key Manager random string: {keyManager.K1}");
            var nodeA = new NodeA(keyManager);
            nodeA.AskForEncryptionKey(keyManager.EncryptKey());
            var nodeB = new NodeB(keyManager);
            nodeB.AskForEncryptionKey(nodeA.EncryptionKey);
            nodeB.SetOperationMode(nodeA.OperationMode);
        }
    }
}

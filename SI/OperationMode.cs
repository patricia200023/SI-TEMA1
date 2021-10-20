abstract class OperationMode
{
    public abstract void Encrypt(string block, string key);
    public abstract void Decrypt(string block, string key);
}
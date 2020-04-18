namespace T9.Infrastructure
{
    public interface IEncodeWorker
    {
        IEncodeWorker SetLine(string text);
        IEncodeWorker EncodeLine();
        string GetEncoded();
    }
}

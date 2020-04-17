namespace T9.Infrastructure
{
    public interface IEncodeWorker
    {
        IEncodeWorker SetLine(string text);
        string EncodeLine();
    }
}

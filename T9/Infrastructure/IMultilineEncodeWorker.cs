namespace T9.Infrastructure
{
    public interface IMultilineEncodeWorker
    {
        IMultilineEncodeWorker SetInitialLines(string text);
        IMultilineEncodeWorker Validate();
        IMultilineEncodeWorker EncodeLines();
    }
}

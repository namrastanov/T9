using System.Collections.Generic;

namespace T9.Infrastructure
{
    public interface IMultilineEncodeWorker
    {
        IMultilineEncodeWorker SetLines(string text);
        IMultilineEncodeWorker Validate();
        IMultilineEncodeWorker EncodeLines();
        IList<string> GetEncodedLines();
    }
}

using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("T9Tests")]
namespace T9.Infrastructure
{
    internal interface IMultilineEncodeWorker
    {
        IMultilineEncodeWorker SetLines(string text);
        IMultilineEncodeWorker Validate();
        IMultilineEncodeWorker EncodeLines();
        IList<string> GetEncodedLines();
    }
}

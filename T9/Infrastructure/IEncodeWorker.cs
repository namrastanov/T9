using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("T9Tests")]
namespace T9.Infrastructure
{
    internal interface IEncodeWorker
    {
        IEncodeWorker SetLine(string text);
        IEncodeWorker EncodeLine();
        string GetEncoded();
    }
}

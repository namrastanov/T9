using System;
using System.Text;
using T9.Infrastructure;

namespace T9.Extensions
{
    public static class EncodeWorkerExtensions
    {
        internal static string BuildEncodeServiceResult(this IMultilineEncodeWorker worker)
        {
            var lines = worker.GetEncodedLines();
            var result = new StringBuilder();
            for (var i = 0; i < lines.Count; i++)
            {
                result.Append($"Case #{i+1}: {lines[i]}");
                if (i < lines.Count-1)
                {
                    result.Append(Environment.NewLine);
                }
            }
            return result.ToString();
        }
    }
}

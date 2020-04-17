using System;
using T9.Infrastructure;

namespace T9.Services
{
    public class EncodeService
    {
        private IMultilineEncodeWorker _encodeWorker;

        public EncodeService(IMultilineEncodeWorker encodeWorker)
        {
            _encodeWorker = encodeWorker;
        }

        public string Encode(string text)
        {
            var result = "";

            return _encodeWorker
                .SetInitialLines(text)
                .Validate()
                .EncodeLines()
                .BuildEncodedResponse();
        }

        public static string BuildEncodedResponse(this IMultilineEncodeWorker encodeWorker)
        {
            return "";
        }
        
    }
}

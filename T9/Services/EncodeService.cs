using T9.Extensions;
using T9.Infrastructure;

namespace T9.Services
{
    public class EncodeService: IEncodeService
    {
        private readonly IMultilineEncodeWorker _encodeWorker;

        public EncodeService(IMultilineEncodeWorker encodeWorker)
        {
            _encodeWorker = encodeWorker;
        }

        public string Encode(string text)
        {
            return _encodeWorker
                    .SetLines(text)
                    .Validate()
                    .EncodeLines()
                    .BuildEncodeServiceResult();
        }
    }
}

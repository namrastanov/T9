using System;
using System.Collections.Generic;
using T9.Exceptions;

namespace T9.Infrastructure
{
    internal class MultilineEncodeWorker: IMultilineEncodeWorker
    {
        private readonly IEncodeWorker _encodeWorker;
        private readonly IList<string> _encodedLines = new List<string>();

        private IList<string> _lines;
        private int _numberOfSentences;

        public MultilineEncodeWorker(IEncodeWorker encodeWorker)
        {
            _encodeWorker = encodeWorker;
        }

        public IMultilineEncodeWorker SetLines(string text)
        {
            _lines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            return this;
        }

        public IMultilineEncodeWorker Validate()
        {
            if (_lines.Count < 1)
            {
                throw new ValidationException("Not enough data");
            }

            if (!int.TryParse(_lines[0], out _numberOfSentences))
            {
                throw new ValidationException("The first line should contain the number of sentences");
            }

            return this;
        }

        public IMultilineEncodeWorker EncodeLines()
        {
            _encodedLines.Clear();
            // take from the second item because the first item was the number of cases
            for (var i = 1; i <= _numberOfSentences; i++)
            {
                _encodedLines.Add(
                    _encodeWorker
                        .SetLine(_lines[i])
                        .EncodeLine()
                        .GetEncoded());
            }

            return this;
        }

        public IList<string> GetEncodedLines()
        {
            return _encodedLines;
        }
    }
}

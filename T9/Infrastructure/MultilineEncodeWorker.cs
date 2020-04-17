using System;
using System.Collections.Generic;
using System.Text;

namespace T9.Infrastructure
{
    public class MultilineEncodeWorker: IMultilineEncodeWorker
    {
        private IList<string> _initialLines;
        private IList<string> _encodedLines;
        private int _numberOfSentences;

        private readonly string EncodedPause = " ";

        public IMultilineEncodeWorker SetInitialLines(string text)
        {
            _initialLines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            return this;
        }

        public IMultilineEncodeWorker Validate()
        {
            if (_initialLines.Count < 1)
            {
                throw new Exception("Not valid");
            }

            if (int.TryParse(_initialLines[0], out _numberOfSentences))
            {
                throw new Exception("The first line should contain the number of sentences");
            }

            return this;
        }

        public IMultilineEncodeWorker EncodeLines()
        {
            foreach(var line in _initialLines)
            {
                _encodedLines.Add(EncodeLine(line));
            }

            return this;
        }

        private string EncodeLine(string line)
        {
            var encodedLine = new StringBuilder();
            char previousLetter = '\0';
            foreach(var letter in line)
            {
                encodedLine.Append(EncodeLetter(letter, letter == previousLetter));
                previousLetter = letter;
            }

            return encodedLine.ToString();
        }

        private string EncodeLetter(char s, bool previousLetterHasSameButton)
        {
            return $"{(previousLetterHasSameButton ? EncodedPause : string.Empty)}{Constants.LetterCodes[s]}";
        }
    }
}

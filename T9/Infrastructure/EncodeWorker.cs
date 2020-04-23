using System.Text;

namespace T9.Infrastructure
{
    internal class EncodeWorker: IEncodeWorker
    {
        private string _line;
        private string _encodedLine;

        private const string ENCODED_PAUSE = " ";

        public IEncodeWorker SetLine(string text)
        {
            _line = text;

            return this;
        }

        public IEncodeWorker EncodeLine()
        {
            _encodedLine = EncodeLine(_line);

            return this;
        }

        public string GetEncoded()
        {
            return _encodedLine;
        }

        private string EncodeLine(string line)
        {
            if (line == null)
            {
                return string.Empty;
            }

            var encodedLine = new StringBuilder();
            string previousEncodedLetter = null;
            foreach(var letter in line)
            {
                var encodedLetter = LetterCodes.GetEncodedLetter(letter);
                encodedLine.Append(EncodeLetter(encodedLetter, previousEncodedLetter));
                previousEncodedLetter = encodedLetter;
            }

            return encodedLine.ToString();
        }

        private string EncodeLetter(string encodedLetter, string previousEncodedLetter)
        {
            return $"{(CheckNeedPause(encodedLetter, previousEncodedLetter) ? ENCODED_PAUSE : string.Empty)}{encodedLetter}";
        }

        private bool CheckNeedPause(string encodedLetter, string previousEncodedLetter)
        {
            return !string.IsNullOrEmpty(previousEncodedLetter) && encodedLetter[0] == previousEncodedLetter[0];
        }
    }
}

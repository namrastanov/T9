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
            var encodedLine = new StringBuilder();
            char? previousLetter = null;
            foreach(var letter in line)
            {
                encodedLine.Append(GetEncodeLetter(letter, previousLetter));
                previousLetter = letter;
            }

            return encodedLine.ToString();
        }

        private string GetEncodeLetter(char letter, char? previousLetter)
        {
            return $"{(CheckNeedPause(letter, previousLetter) ? ENCODED_PAUSE : string.Empty)}{LetterCodes.GetEncodedLetter(letter)}";
        }

        private bool CheckNeedPause(char letter, char? previousLetter)
        {
            return previousLetter.HasValue && LetterCodes.GetLetterCode(letter) == LetterCodes.GetLetterCode(previousLetter.Value);
        }
    }
}

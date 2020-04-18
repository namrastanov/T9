using System.Text;

namespace T9.Infrastructure
{
    public class EncodeWorker: IEncodeWorker
    {
        private string _line;
        private string _encodedLine;

        private readonly string EncodedPause = " ";

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
                encodedLine.Append(EncodeLetter(letter, previousLetter));
                previousLetter = letter;
            }

            return encodedLine.ToString();
        }

        private string EncodeLetter(char letter, char? previousLetter)
        {
            return $"{(CheckNeedPause(letter, previousLetter) ? EncodedPause : string.Empty)}{Constants.LetterCodes[letter]}";
        }

        private bool CheckNeedPause(char letter, char? previousLetter)
        {
            return previousLetter.HasValue && Constants.LetterCodes[letter][0] == Constants.LetterCodes[previousLetter.Value][0];
        }
    }
}

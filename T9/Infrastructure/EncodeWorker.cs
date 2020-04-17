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

        public string EncodeLine()
        {
            _encodedLine = EncodeLine(_line);

            return _encodedLine;
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

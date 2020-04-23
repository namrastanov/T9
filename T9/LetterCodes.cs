using System;
using System.Collections.Generic;
using System.Linq;
using T9.Exceptions;

namespace T9
{
    public static class LetterCodes
    {
        private static readonly IDictionary<char, string> _letterCodes = new Dictionary<char, string>()
        {
            {'a', "2" },
            {'b', "22" },
            {'c', "222" },
            {'d', "3" },
            {'e', "33" },
            {'f', "333" },
            {'g', "4" },
            {'h', "44" },
            {'i', "444" },
            {'j', "5" },
            {'k', "55" },
            {'l', "555" },
            {'m', "6" },
            {'n', "66" },
            {'o', "666" },
            {'p', "7" },
            {'q', "77" },
            {'r', "777" },
            {'s', "7777" },
            {'t', "8" },
            {'u', "88" },
            {'v', "888" },
            {'w', "9" },
            {'x', "99" },
            {'y', "999" },
            {'z', "9999" },
            {' ', "0" }
        };

        public static string GetEncodedLetter(char letter)
        {
            if (_letterCodes.TryGetValue(letter, out string encodedLetter))
            {
                return encodedLetter;
            } else
            {
                throw new ValidationException($"Letter {letter} is not supported");
            }
        }

        public static char GetLetterCode(char letter)
        {
            return GetEncodedLetter(letter)[0];
        }
    }
}

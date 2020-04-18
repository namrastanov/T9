using System.Collections.Generic;

namespace T9Tests
{
    internal static class Constants
    {
        internal static string HELLO_WORLD = "hello world";
        internal static string THE_SECOND_LINE = "the second line";

        internal static IDictionary<string, string> TestCases = new Dictionary<string, string>
        {
            {
                "4\r\nhi\r\nyes\r\nfoo  bar\r\nhello world",
                "Case #1: 44 444\r\nCase #2: 999337777\r\nCase #3: 333666 6660 022 2777\r\nCase #4: 4433555 555666096667775553" },
            {
                HELLO_WORLD,
                "4433555 555666096667775553"
            },
            {
                THE_SECOND_LINE,
                "844330777733222666 66305554446633"
            }
        };
    }
}

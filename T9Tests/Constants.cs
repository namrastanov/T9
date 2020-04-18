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

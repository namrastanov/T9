using T9.Services;
using Xunit;

namespace T9Tests
{
    public class ParserTest
    {
        [Fact]
        public void T9Encode()
        {
            var text = "4\r\nhi\r\nyes\r\nfoo bar\r\nhello world";
            var mustReturn = "Case #1: 44 444\r\nCase #2: 999337777\r\nCase #3: 333666 6660 022 2777\r\nCase #4: 4433555 555666096667775553";

            var parser = new EncodeService();
            var result = parser.Encode(text);

            Assert.NotNull(result);
            Assert.Equal(result, mustReturn);
        }
    }
}

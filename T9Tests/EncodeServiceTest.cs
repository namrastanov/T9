using T9.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace T9Tests
{
    public class EncodeServiceTest
    {
        private readonly IEncodeService _encodeService;

        public EncodeServiceTest()
        {
            var serviceProvider = DI.GetServiceProvider();

            _encodeService = serviceProvider.GetService<IEncodeService>();
        }

        [Fact]
        public void T9Encode()
        {
            var text = "4\r\nhi\r\nyes\r\nfoo  bar\r\nhello world";
            var mustReturn = "Case #1: 44 444\r\nCase #2: 999337777\r\nCase #3: 333666 6660 022 2777\r\nCase #4: 4433555 555666096667775553";

            var result = _encodeService.Encode(text);

            Assert.NotNull(result);
            Assert.Equal(result, mustReturn);
        }
    }
}

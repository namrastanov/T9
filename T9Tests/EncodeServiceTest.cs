using T9.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Linq;

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
            var testCase = Constants.TestCases.First();

            var result = _encodeService.Encode(testCase.Key);

            Assert.NotNull(result);
            Assert.Equal(result, testCase.Value);
        }
    }
}

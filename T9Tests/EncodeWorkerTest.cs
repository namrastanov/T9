using T9.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using T9.Infrastructure;

namespace T9Tests
{
    public class EncodeWorkerTest
    {
        private readonly IEncodeWorker _encodeWorker;

        public EncodeWorkerTest()
        {
            var serviceProvider = DI.GetServiceProvider();

            _encodeWorker = serviceProvider.GetService<IEncodeWorker>();
        }

        [Fact]
        public void EncodeLine()
        {
            var result = _encodeWorker
                .SetLine(Constants.HELLO_WORLD)
                .EncodeLine()
                .GetEncoded();

            Assert.NotNull(result);
            Assert.Equal(result, Constants.TestCases[Constants.HELLO_WORLD]);
        }
    }
}

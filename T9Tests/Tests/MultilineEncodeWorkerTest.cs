using Microsoft.Extensions.DependencyInjection;
using Xunit;
using T9.Infrastructure;

namespace T9Tests.Tests
{
    public class MultilineEncodeWorkerTest
    {
        private readonly IMultilineEncodeWorker _mulitlineEncodeWorker;

        public MultilineEncodeWorkerTest()
        {
            var serviceProvider = DI.GetServiceProvider();

            _mulitlineEncodeWorker = serviceProvider.GetService<IMultilineEncodeWorker>();
        }

        [Fact]
        public void MultilineEncode()
        {
            var mustReturnCount = 2;
            var text = $"{mustReturnCount}\r\n{Constants.HELLO_WORLD}\r\n{Constants.THE_SECOND_LINE}";

            var result = _mulitlineEncodeWorker
                .SetLines(text)
                .Validate()
                .EncodeLines()
                .GetEncodedLines();

            Assert.NotNull(result);
            Assert.Equal(result.Count, mustReturnCount);
            Assert.Equal(result[0], Constants.TestCases[Constants.HELLO_WORLD]);
            Assert.Equal(result[1], Constants.TestCases[Constants.THE_SECOND_LINE]);
        }
    }
}

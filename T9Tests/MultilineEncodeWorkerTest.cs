using Microsoft.Extensions.DependencyInjection;
using Xunit;
using T9.Infrastructure;

namespace T9Tests
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
            var text = "hello world\r\nim the second line";
            var mustReturnCount = 2;
            var mustReturn_1stLine = "4433555 555666096667775553";
            var mustReturn_2ndLine = "44460844330777733222666 66305554446633";

            var result = _mulitlineEncodeWorker
                .SetLines(text)
                .Validate()
                .EncodeLines()
                .GetEncodedLines();

            Assert.NotNull(result);
            Assert.Equal(result.Count, mustReturnCount);
            Assert.Equal(result[0], mustReturn_1stLine);
            Assert.Equal(result[1], mustReturn_2ndLine);
        }
    }
}

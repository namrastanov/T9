using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Text;
using T9.Exceptions;
using T9.Services;

namespace T9Console
{
    internal class ProgramRunner
    {
        private static IEncodeService _encodeService;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ProgramRunner Init()
        {
            var serviceProvider = DI.GetServiceProvider();
            _encodeService = serviceProvider.GetService<IEncodeService>();

            return this;
        }

        public void Run()
        {
            var inputParameterBuilder = new StringBuilder();
            for (; ; )
            {
                Console.WriteLine(">Please, enter the number of lines:");
                var numberOfLinesStr = Console.ReadLine();
                if (int.TryParse(numberOfLinesStr, out int numberOfLines))
                {
                    inputParameterBuilder
                        .Append(numberOfLines)
                        .Append(Environment.NewLine);

                    for (int i = 0; i < numberOfLines; i++)
                    {
                        Console.WriteLine($">Enter text for T9 encode ({numberOfLines - i} left):");
                        inputParameterBuilder
                            .Append(Console.ReadLine())
                            .Append(Environment.NewLine);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong number");
                    continue;
                }

                string encodedResult;
                try
                {
                    encodedResult = _encodeService.Encode(inputParameterBuilder.ToString());
                } catch(CustomException ex)
                {
                    _logger.Error(ex.Message);
                    continue;
                }

                Console.WriteLine("T9 encoded text:");
                Console.WriteLine(encodedResult);
                Console.WriteLine(">Do you like input more (y/n):");
                if (Console.ReadKey().KeyChar == 'n')
                {
                    break;
                }

                inputParameterBuilder.Clear();
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}

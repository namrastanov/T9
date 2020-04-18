using NLog;
using System;
using T9.Exceptions;

namespace T9Console.Handlers
{
    internal static class ExceptionHandler
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static void T9ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;

            _logger.Error(ex);

            LogManager.Shutdown();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}

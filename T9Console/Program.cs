using System;
using T9Console.Handlers;

namespace T9Console
{
    internal class Program
    {
        public static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler.T9ExceptionHandler);

            new ProgramRunner()
                .Init()
                .Run();
        }

        
    }
}

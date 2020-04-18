using Microsoft.Extensions.DependencyInjection;
using System;
using T9Console.Extensions;

namespace T9Console
{
    internal static class DI
    {
        internal static IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .RegisterT9InternalDI()
                .BuildServiceProvider();
        }
    }
}

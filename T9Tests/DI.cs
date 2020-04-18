using Microsoft.Extensions.DependencyInjection;
using System;
using T9.IoC;

namespace T9Tests
{
    internal static class DI
    {
        internal static IServiceProvider GetServiceProvider()
        {
            var moduleDI = new ModuleDI();
            var services = new ServiceCollection();

            return moduleDI
                .RegisterDependencies(services)
                .BuildServiceProvider();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using System;
using T9.Infrastructure;
using T9.IoC;
using T9.Services;

namespace T9Tests
{
    internal static class DI
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            /*services.AddScoped<IInternalDI, InternalDI>();

            var provider = services.BuildServiceProvider();

            var indernalDi = provider.GetService<IInternalDI>();
            indernalDi.RegisterDependencies(services);*/

            services.AddScoped<IEncodeWorker, EncodeWorker>();
            services.AddScoped<IMultilineEncodeWorker, MultilineEncodeWorker>();
            services.AddScoped<IEncodeService, EncodeService>();

            return services.BuildServiceProvider();
        }
    }
}
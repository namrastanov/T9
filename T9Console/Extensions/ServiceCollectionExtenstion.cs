using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using T9.IoC;

namespace T9Console.Extensions
{
    public static class ServiceCollectionExtenstion
    {
        public static IServiceCollection RegisterT9InternalDI(this IServiceCollection services)
        {
            var modulesDITypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IModuleDI).IsAssignableFrom(p) && !p.IsInterface);

            foreach(var moduleDIType in modulesDITypes)
            {
                ((IModuleDI)Activator
                    .CreateInstance(moduleDIType))
                    .RegisterDependencies(services);
            }

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using T9.Infrastructure;
using T9.Services;

namespace T9.IoC
{
    public class ModuleDI: IModuleDI
    {
        public IServiceCollection RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IEncodeWorker, EncodeWorker>();
            services.AddScoped<IMultilineEncodeWorker, MultilineEncodeWorker>();
            services.AddScoped<IEncodeService, EncodeService>();

            return services;
        }
    }
}

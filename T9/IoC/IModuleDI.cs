using Microsoft.Extensions.DependencyInjection;

namespace T9.IoC
{
    public interface IModuleDI
    {
        void RegisterDependencies(IServiceCollection services);
    }
}

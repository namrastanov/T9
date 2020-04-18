using Microsoft.Extensions.DependencyInjection;

namespace T9.IoC
{
    public interface IInternalDI
    {
        void RegisterDependencies(IServiceCollection services);
    }
}

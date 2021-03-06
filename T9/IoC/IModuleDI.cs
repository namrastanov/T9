﻿using Microsoft.Extensions.DependencyInjection;

namespace T9.IoC
{
    public interface IModuleDI
    {
        IServiceCollection RegisterDependencies(IServiceCollection services);
    }
}

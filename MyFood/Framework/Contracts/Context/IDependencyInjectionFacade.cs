using System;

namespace MyFood.Framework.Contracts.Context
{
    public interface IDependencyInjectionFacade
    {
        Object GetService(Type type);
        TService GetService<TService>();
    }
}

using Microsoft.Extensions.DependencyInjection;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using SimpleInjector;
using System;

namespace MyFood.Framework.Context
{
    public class DependencyInjectionFacade : IDependencyInjectionFacade
    {
        private Container Container;
        public DependencyInjectionFacade(Container container)
        {
            Container = container;
        }

        public object GetService(Type type)
        {
            return Container.GetInstance(type);
        }

        public TService GetService<TService>()
        {
            return Container.GetService<TService>();
        }
    }
}

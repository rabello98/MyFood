using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Framework.Contracts.Context
{
    public interface IDependencyInjectionFacade
    {
        Object GetService(Type type);
    }
}

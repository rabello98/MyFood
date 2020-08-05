using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Framework.Contracts.AppStart
{
    public interface IDependencyInjectionFacade
    {
        Object GetService(Type type);
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Framework.Contracts.Context
{
    public interface IMyFoodAppContext
    {
        IConfiguration Configuration { get; set; }
        IDependencyInjectionFacade Resolver { get; set; }
        IDictionary<String, Object> Params { get; set; }
    }
}

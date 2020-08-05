using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MyFood.Framework.Contracts.Context
{
    public interface IMyFoodAppContext
    {
        IConfiguration Configuration { get; set; }
        IDependencyInjectionFacade Resolver { get; set; }
        IDictionary<String, Object> Params { get; set; }
    }
}

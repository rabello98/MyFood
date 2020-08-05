using Microsoft.Extensions.Configuration;
using MyFood.Framework.Contracts.Context;
using System;
using System.Collections.Generic;

namespace MyFood.Framework.Context
{
    public class MyFoodAppContext : IMyFoodAppContext
    {
        public IConfiguration Configuration { get; set; }
        public IDependencyInjectionFacade Resolver { get; set; }
        public IDictionary<String, Object> Params { get; set; }

        public MyFoodAppContext(IConfiguration configuration, IDependencyInjectionFacade resolver)
        {
            Configuration = configuration;
            Resolver = resolver;
            Params = new Dictionary<String, Object>();
        }
    }
}

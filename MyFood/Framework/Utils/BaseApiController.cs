using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;

namespace MyFood.Framework.Utils
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController<TEntity, TModel> : ControllerBase 
        where TEntity : class 
        where TModel : class
    {
        protected virtual IRepository<TModel> Repository { get; set; }
        protected virtual IMapper Mapper { get; set; }
        protected virtual IMyFoodAppContext AppContext { get; set; }
        protected virtual IDependencyInjectionFacade Resolver { get; set; }

        public BaseApiController(IRepository<TModel> repository, IMapper mapper, IMyFoodAppContext appContext)
        {
            Repository = repository;
            Mapper = mapper;
            AppContext = appContext;
            Resolver = AppContext.Resolver;
        }

        [HttpGet]
        public virtual IEnumerable<TModel> Get()
        {
            var res = Repository.All();
            return res;
        }

        [HttpGet("{id}")]
        public virtual string Get(int id)
        {
            return typeof(TModel).ToString();
        }

        [HttpPost]
        public virtual void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
        }
    }
}

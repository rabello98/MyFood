using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        IDependencyInjectionFacade Resolver { get; set; }

        public BaseApiController(IRepository<TModel> repository, IMapper mapper, IDependencyInjectionFacade resolver)
        {
            Repository = repository;
            Mapper = mapper;
            Resolver = resolver;
        }

        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

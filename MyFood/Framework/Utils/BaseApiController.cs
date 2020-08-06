﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Model;
using MyFood.ViewModel;
using System;
using System.Linq;

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
        public virtual IQueryable<TEntity> Get()
        {
            try
            {
                return Repository.All().ProjectTo<TEntity>(Mapper.ConfigurationProvider);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        public virtual TEntity Get(int id)
        {
            try
            {
                var data = Repository.GetById(id);
                return Mapper.Map<TModel, TEntity>(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public virtual void Post(TEntity entity)
        {
            try
            {
                var data = Mapper.Map<TEntity, TModel>(entity);
                Repository.Insert(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("{id}")]
        public virtual void Put(int id, TEntity entity)
        {
            try
            {
                var data = Repository.GetById(id);
                Mapper.Map(entity, data);
                Repository.Update(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
            try
            {
                Repository.DeleteById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyFood.Framework.Contracts.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyFood.Framework.DAO
{
    public class BaseRepository<TModel> : IRepository<TModel> where TModel : class
    {
        private DbSet<TModel> Set { get; set; }
        private MyFoodContext Context { get; set; }  
        public BaseRepository(MyFoodContext context)
        {
            Context = context;
            Set = Context.Set<TModel>();
        }
        public TModel GetById(Int64 id)
        {
            try
            {
                return Set.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<TModel> Query()
        {
            try
            {
                return Set;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<TModel> All()
        {
            try
            {
                return Set.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(TModel data)
        {
            try
            {
                Set.Add(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Attach(TModel data)
        {
            try
            {
                Set.Attach(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(TModel data)
        {
            try
            {
                Context.Entry(data).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(TModel data)
        {
            try
            {
                Set.Remove(data);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteById(Int64 id)
        {
            var data = GetById(id);
            Delete(data);
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyFood.Framework.Contracts.DAO;
using System;
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
            return Set.Find(id);
        }

        public IQueryable<TModel> All()
        {
            return Set;
        }

        public void Insert(TModel data)
        {
            Set.Add(data);
        }

        public void Update(TModel data)
        {
            Context.Entry(data).State = EntityState.Modified;
        }

        public void Delete(TModel data)
        {
            Set.Remove(data);
        }

        public void DeleteById(Int64 id)
        {
            var data = GetById(id);
            Delete(data);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}

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
        public TModel GetById(String Id)
        {
            return null;
        }
    }
}

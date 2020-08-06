using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Framework.Contracts.DAO
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel GetById(Int64 id);
        IQueryable<TModel> All();
        void Insert(TModel data);
        void Update(TModel data);
        void Delete(TModel data);
        void DeleteById(Int64 id);
        void SaveChanges();
    }
}

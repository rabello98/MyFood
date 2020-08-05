using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Framework.Contracts.DAO
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel GetById(String id);
        IEnumerable<TModel> All();
    }
}

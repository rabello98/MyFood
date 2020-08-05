using MyFood.Framework.Contracts.DAO;
using System;

namespace MyFood.Framework.DAO
{
    public class BaseRepository<TModel> : IRepository<TModel> where TModel : class
    {
        public TModel GetById(String Id)
        {
            return null;
        }
    }
}

using AutoMapper;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.Utils;
using MyFood.Model;
using MyFood.ViewModel;

namespace MyFood.Controllers
{
    public class ProdutoController : BaseApiController<ProdutoView, Produto>
    {
        public ProdutoController(IRepository<Produto> repository,
            IMapper mapper, IMyFoodAppContext appContext) : base(repository, mapper, appContext)
        {

        }
    }
}

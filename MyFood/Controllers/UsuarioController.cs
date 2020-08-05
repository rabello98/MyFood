using AutoMapper;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.Utils;
using MyFood.Model;
using MyFood.ViewModel;

namespace MyFood.Controllers
{
    public class UsuarioController : BaseApiController<UsuarioView, Usuario>
    {
        public UsuarioController(IRepository<Usuario> repository,
            IMapper mapper, IMyFoodAppContext appContext) : base(repository, mapper, appContext)
        {

        }
    }
}

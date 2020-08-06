﻿using AutoMapper;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.Utils;
using MyFood.Model;
using MyFood.ViewModel;

namespace MyFood.Controllers
{
    public class PedidoController : BaseApiController<PedidoView, Pedido>
    {
        public PedidoController(IRepository<Pedido> repository,
            IMapper mapper, IMyFoodAppContext appContext) : base(repository, mapper, appContext)
        {

        }
    }
}
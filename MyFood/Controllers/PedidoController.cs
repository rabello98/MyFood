using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.DAO;
using MyFood.Framework.Utils;
using MyFood.Model;
using MyFood.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace MyFood.Controllers
{
    public class PedidoController : BaseApiController<PedidoView, Pedido>
    {
        public IRepository<Produto> ProdutoRepository { get; set; }
        public IRepository<Usuario> UserRepository { get; set; }
        public PedidoController(IRepository<Pedido> repository, IMapper mapper, IMyFoodAppContext appContext, 
            IRepository<Usuario> userRepository, IRepository<Produto> produtoRepository) : base(repository, mapper, appContext)
        {
            UserRepository = userRepository;
            ProdutoRepository = produtoRepository;
        }

        [HttpPost]
        public override void Post(dynamic value)
        {
            var json = JObject.Parse(value.ToString());

            var pagamento = (PagamentoCartaoView)JsonConvert.DeserializeObject<PagamentoCartaoView>(json.Pagamento.ToString());

            var pedidoView = (PedidoView)JsonConvert.DeserializeObject<PedidoView>(json.Pedido.ToString());
            var pedido = Mapper.Map<PedidoView, Pedido>(pedidoView);

            pedido.UsuarioId = UserRepository.All()
                .Where(u => u.Cpf.Equals(pedidoView.UsuarioCpf))
                .Select(u => u.Id)
                .FirstOrDefault();

            foreach(var pedidoProduto in pedido.Produtos)
            {
                var produto = ProdutoRepository.GetById(pedidoProduto.ProdutoId);
                pedido.ValorTotal += produto.Preco;
            }

            pedido.Finalizado = "S";
            pedido.Pago = "S";

            Repository.Insert(pedido);
            Repository.SaveChanges();
        }
    }
}

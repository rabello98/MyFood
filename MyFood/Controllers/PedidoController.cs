using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.Contracts.Service;
using MyFood.Framework.Utils;
using MyFood.Model;
using MyFood.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Transactions;

namespace MyFood.Controllers
{
    public class PedidoController : BaseApiController<PedidoView, Pedido>
    {
        public IRepository<Produto> ProdutoRepository { get; set; }
        public IRepository<Usuario> UserRepository { get; set; }
        public ICreditCardValidatorService CreditCardValidator { get; set; }
        public PedidoController(IRepository<Pedido> repository, IMapper mapper, IMyFoodAppContext appContext, 
            IRepository<Usuario> userRepository, IRepository<Produto> produtoRepository,
            ICreditCardValidatorService creditCardValidator) : base(repository, mapper, appContext)
        {
            UserRepository = userRepository;
            ProdutoRepository = produtoRepository;
            CreditCardValidator = creditCardValidator;
        }

        [HttpPost]
        public override JsonResult Post(dynamic value)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var json = JObject.Parse(value.ToString());

                    var pagamento = (PagamentoCartaoView)JsonConvert.DeserializeObject<PagamentoCartaoView>(json.Pagamento.ToString());

                    var pedidoView = (PedidoView)JsonConvert.DeserializeObject<PedidoView>(json.Pedido.ToString());
                    var pedido = Mapper.Map<PedidoView, Pedido>(pedidoView);

                    var creditCardIsValid = CreditCardValidator.Validate(pagamento, pedidoView.FormaPagamento);

                    if (!creditCardIsValid)
                        throw new InvalidOperationException("Credit card is not valid");

                    pedido.Pago = "S";

                    pedido.UsuarioId = UserRepository.Query()
                        .Where(u => u.Cpf.Equals(pedidoView.UsuarioCpf))
                        .Select(u => u.Id)
                        .FirstOrDefault();

                    foreach (var pedidoProduto in pedido.Produtos)
                    {
                        var produto = ProdutoRepository.GetById(pedidoProduto.ProdutoId);
                        pedido.ValorTotal += produto.Preco;
                    }

                    pedido.Finalizado = "S";

                    Repository.Insert(pedido);
                    Repository.SaveChanges();

                    transaction.Complete();

                    return new JsonResult(new { Status = "success", Message = "Pedido realizado com sucesso! utilize seu CPF para consultar" });
                }
                catch(Exception e)
                {
                    return new JsonResult(new { Status = "error", Message = e.Message });
                }
            }
        }

        [HttpGet]
        [Route("MeusPedidos/{cpf}")]
        public IQueryable<PedidoView> GetPedidosUser(string cpf)
        {
            try
            {
                var user = UserRepository.Query().Where(u => u.Cpf.Equals(cpf)).FirstOrDefault();
                var pedidos = Repository.Query().Where(p => p.UsuarioId.Equals(user.Id))
                    .ProjectTo<PedidoView>(Mapper.ConfigurationProvider);

                return pedidos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

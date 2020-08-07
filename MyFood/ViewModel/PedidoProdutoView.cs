using MyFood.Framework.Attribures;
using MyFood.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    [MapTo(typeof(PedidoProduto))]
    public class PedidoProdutoView
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 PedidoId { get; set; }
        public Int64 ProdutoId { get; set; }
        public String ProdutoNome { get; set; }
        public String ProdutoPreco { get; set; }
        public Int64 Quantidade { get; set; }
    }
}

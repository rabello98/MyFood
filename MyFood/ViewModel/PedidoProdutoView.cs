using MyFood.Framework.Attribures;
using MyFood.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    public class PedidoProdutoView
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 PedidoId { get; set; }
        public PedidoView PedidoView { get; set; }
        public Int64 ProdutoId { get; set; }
        public ProdutoView ProdutoView { get; set; }
        public Int64 Quantidade { get; set; }
    }
}

using MyFood.Framework.Attribures;
using MyFood.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    [MapTo(typeof(Pedido))]
    public class PedidoView
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 UsuarioId { get; set; }

        public Decimal ValorTotal { get; set; }

        public String FormaPagamento { get; set; }

        public String Pago { get; set; }

        public String Finalizado { get; set; }

        public IEnumerable<PedidoProdutoView> Produtos { get; set; }
    }
}

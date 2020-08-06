using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    public class PedidoProdutoView
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 PedidoId { get; set; }

        public String ProdutoId { get; set; }

        public Int64 Quantidade { get; set; }
    }
}

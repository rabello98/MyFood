using MyFood.Framework.Attribures;
using MyFood.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    [MapTo(typeof(Produto))]
    public class ProdutoView
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public Int64 EmpresaId { get; set; }

        public EmpresaView Empresa { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Descricao { get; set; }

        [Required]
        public Decimal Preco { get; set; }

        public IEnumerable<PedidoProdutoView> Pedidos {get; set;}
    }
}

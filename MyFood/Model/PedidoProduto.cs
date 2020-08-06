using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("OPR_PEDIDO_PRODUTO")]
    public class PedidoProduto
    {
        [Key]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("PEDIDO_ID")]
        [ForeignKey("Pedido")]
        public Int64 PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        [Column("PRODUTO_ID")]
        [ForeignKey("Produto")]
        public Int64 ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Column("QUANTIDADE")]
        public Int64 Quantidade { get; set; }
    }
}

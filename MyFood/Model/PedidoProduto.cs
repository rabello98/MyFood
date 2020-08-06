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
        public Int64 PedidoId { get; set; }

        [Column("PRODUTO_ID")]
        public String ProdutoId { get; set; }

        [Column("QUANTIDADE")]
        public Int64 Quantidade { get; set; }
    }
}

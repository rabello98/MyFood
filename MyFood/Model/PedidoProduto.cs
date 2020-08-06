using MyFood.Framework.Attribures;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("OPR_PEDIDO_PRODUTO")]
    public class PedidoProduto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("PEDIDO_ID")]
        [ForeignKey("Pedido")]
        public Int64 PedidoId { get; set; }
        [IgnoreMap]
        public Pedido Pedido { get; set; }

        [Column("PRODUTO_ID")]
        [ForeignKey("Produto")]
        public Int64 ProdutoId { get; set; }
        [IgnoreMap]
        public Produto Produto { get; set; }

        [Column("QUANTIDADE")]
        public Int64 Quantidade { get; set; }
    }
}

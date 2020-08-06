using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("OPR_PEDIDO")]
    public class Pedido
    {
        [Key]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("USUARIO_ID")]
        public Int64 UsuarioId { get; set; }

        [Column("VALOR_TOTAL")]
        public Decimal ValorTotal { get; set; }

        [Column("FORMA_PAGAMENTO")]
        public String FormaPagamento { get; set; }

        [Column("PAGO")]
        public String Pago { get; set; }

        [Column("FINALIZADO")]
        public String Finalizado { get; set; }
    }
}

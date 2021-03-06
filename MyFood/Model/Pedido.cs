﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MyFood.Model
{
    [Table("OPR_PEDIDO")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("USUARIO_ID")]
        [ForeignKey("Usuario")]
        public Int64 UsuarioId { get; set; }
        [IgnoreMap]
        public Usuario Usuario { get; set; }
        [Column("VALOR_TOTAL")]
        public Decimal ValorTotal { get; set; }

        [Column("FORMA_PAGAMENTO")]
        public String FormaPagamento { get; set; }

        [Column("PAGO")]
        public String Pago { get; set; }

        [Column("FINALIZADO")]
        public String Finalizado { get; set; }

        public IEnumerable<PedidoProduto> Produtos { get; set; }
    }
}

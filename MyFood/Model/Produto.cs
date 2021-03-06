﻿using MyFood.Framework.Attribures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("CAD_PRODUTO")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("EMPRESA_ID")]
        [ForeignKey("Empresa")]
        public Int64 EmpresaId { get; set; }
        [IgnoreMap]
        public Empresa Empresa { get; set; }

        [Column("NOME")]
        public String Nome { get; set; }

        [Column("DESCRICAO")]
        public String Descricao { get; set; }

        [Column("PRECO")]
        public Decimal Preco { get; set; }

        [IgnoreMap]
        public IEnumerable<PedidoProduto> Pedidos { get; set; }
    }
}

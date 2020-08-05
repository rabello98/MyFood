﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("CAD_USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("NOME")]
        public String Nome { get; set; }

        [Column("EMAIL")]
        public String Email { get; set; }

        [Column("CPF")]
        public String Cpf { get; set; }
    }
}
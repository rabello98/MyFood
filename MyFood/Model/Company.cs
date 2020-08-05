﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MyFood.Model
{
    [Table("COMPANY")]
    public class Company
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


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("CAD_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("NOME")]
        public String Nome { get; set; }

        [Column("EMAIL")]
        public String Email { get; set; }

        [Column("CPF")]
        public String Cpf { get; set; }

        [Column("ENDERECO")]
        public String Endereco { get; set; }

        [Column("NUMERO")]
        public String Numero { get; set; }

        [Column("CEP")]
        public String Cep { get; set; }  
    }
}

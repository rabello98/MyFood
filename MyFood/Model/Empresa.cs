using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("CAD_EMPRESA")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("RAZAO_SOCIAL")]
        public String RazaoSocial { get; set; }

        [Column("NOME_FANTASIA")]
        public String NomeFantasia { get; set; }

        [Column("CNPJ")]
        public String Cnpj { get; set; }
    }
}

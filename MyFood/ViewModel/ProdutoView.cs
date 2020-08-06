using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    public class ProdutoView
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 EmpresaId { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public Decimal Preco { get; set; }
    }
}

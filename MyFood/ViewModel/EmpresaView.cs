using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    public class EmpresaView
    {
        [Key]
        public Int64 Id { get; set; }

        public String RazaoSocial { get; set; }

        public String NomeFantasia { get; set; }

        public String Cnpj { get; set; }
    }
}

using MyFood.Framework.Attribures;
using MyFood.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    [MapTo(typeof(Empresa))]
    public class EmpresaView
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public String RazaoSocial { get; set; }

        [Required]
        public String NomeFantasia { get; set; }

        [Required]
        public String Cnpj { get; set; }
    }
}

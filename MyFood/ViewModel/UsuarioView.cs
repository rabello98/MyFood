using MyFood.Framework.Attribures;
using MyFood.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.ViewModel
{
    [MapTo(typeof(Usuario))]
    public class UsuarioView 
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Cpf { get; set; }
    }
}

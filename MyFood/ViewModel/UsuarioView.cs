using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFood.ViewModel
{
    public class UsuarioView 
    {
        [Key]
        public Int64 Id { get; set; }

        public String Nome { get; set; }

        public String Email { get; set; }

        public String Cpf { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFood.Model
{
    [Table("COMPANY")]
    public class Company
    {
        [Key]
        [Column("ID")]
        public Int64 Id { get; set; }

        [Column("NAME")]
        public String Name { get; set; }
    }
}

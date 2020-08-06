using Microsoft.EntityFrameworkCore;
using MyFood.Model;

namespace MyFood.Framework.DAO
{
    public class MyFoodContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public MyFoodContext(DbContextOptions<MyFoodContext> options) : base(options)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

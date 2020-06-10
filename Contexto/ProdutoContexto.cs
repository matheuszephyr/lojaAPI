using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Contexto
{
    public class ProdutoContexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }         
        public DbSet<Usuario> Usuarios { get; set; }

        public ProdutoContexto(DbContextOptions<ProdutoContexto> options) :
            base(options)
        {
        }
    
    }
}

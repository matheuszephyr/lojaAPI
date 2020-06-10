using LojaAPI.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Contexto
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoCesta> TodosProdutos { get; set; }

        public DbSet<ProdutoCesta> TodaCesta { get; set; }

        public DbSet<Usuario> TodoUsuario { get; set; }

        public DbSet<Pedido> TodoPedido { get; set; }
    
    }
}

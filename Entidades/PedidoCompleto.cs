using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Entidades
{
    public class PedidoCompleto
    {

        public int IdPedido { get; set; }
        public List<ProdutoCesta> Produtos { get; set; }
        public int IdUsuario { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Entidades
{
    public class ProdutoCesta
    {
        //[Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public string Imagem { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Contexto
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        [Column("idproduto")]
        public int IdProduto { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("imagem")]
        public string Imagem { get; set; }
        [Column("valor")]
        public decimal Valor { get; set; }

    }
}

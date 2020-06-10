using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Contexto
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Column("idtblpedido")]
        public int IdTblPedido { get; set; }
        [Column("idpedido")]
        public int IdPedido { get; set; }
        [Column("idproduto")]
        public int IdProduto { get; set; }        
        [Column("valor")]
        public decimal Valor { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Column("total")]
        public decimal Total { get; set; }
        [Column("idusuario")]
        public int IdUsuario { get; set; }
    }
}

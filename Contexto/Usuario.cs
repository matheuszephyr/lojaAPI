using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Contexto
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("idusuario")]
        public int IdUsuario { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public int Telefone { get; set; }
    }
}

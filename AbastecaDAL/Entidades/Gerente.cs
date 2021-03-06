using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Gerente
    {
        [Key]
        public int GerenteID { get; set; }
        [Required]
        [ForeignKey("UsuarioID")]
        public int UsuarioID { get; set; }

        public Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Supervisor
    {
        [Key]
        public int SupervisorID { get; set; }
        [Required]
        [ForeignKey("UsuarioID")]
        public int UsuarioID { get; set; }
        [Required]
        [ForeignKey("BombaID")]
        public int BombaID { get; set; }

        public Usuario Usuario { get; set; }
        public Bomba Bomba { get; set; }
    }
}

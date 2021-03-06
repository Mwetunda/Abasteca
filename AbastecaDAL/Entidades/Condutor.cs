using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Condutor
    {
        [Key]
        public int CondutorID { get; set; }
        [Required]
        [ForeignKey("UsuarioID")]
        public int UsuarioID { get; set; }
        [Required]
        [ForeignKey("MunicipioID")]
        public int MunicipioID { get; set; }

        public Usuario Usuario { get; set; }
        public Municipio Municipio { get; set; }
    }
}

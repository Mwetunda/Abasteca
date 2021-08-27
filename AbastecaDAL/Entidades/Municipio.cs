using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Municipio
    {

        [Key]
        public int MunicipioID { get; set; }
        [Required]
        public string Nome { get; set; }
        [ForeignKey("ProvinciaID")]
        public int ProvinciaID { get; set; }
    }
}

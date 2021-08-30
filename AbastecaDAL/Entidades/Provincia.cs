using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Provincia
    {
        [Key]
        public int ProvinciaID { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<Municipio> Municipios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Operadora
    {
        [Key]
        public int OperadoraID { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<Bomba> Bombas { get; set; }
    }
}

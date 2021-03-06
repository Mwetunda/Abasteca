using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDAL.Entidades
{
    public class Bomba
    {
        [Key]
        public Guid BombaID { get; set; }
        [Required]
        [ForeignKey("OperadoraID")]
        public int OperadoraID { get; set; }
        [Required]
        [ForeignKey("MunicipioID")]
        public int MunicipioID { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public int Sinal { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataActualizacao { get; set; }

        public Municipio Municipio { get; set; }
        public Operadora Operadora { get; set; }
        public ICollection<Supervisor> Supervisors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class BombasDTO
    {
        public Guid BombaID { get; set; }
        [Required]
        public int OperadoraID { get; set; }
        [Required]
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

        public MunicipioDTO Municipio { get; set; }
        public OperadoraDTO Operadora { get; set; }
        public ICollection<SupervisorDTO> Supervisors { get; set; }
    }
    public class BombasDTOcriar
    {
        public Guid BombaID { get; set; }
        [Required]
        public int OperadoraID { get; set; }
        [Required]
        public int MunicipioID { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public int Sinal { get; set; }
    }
}

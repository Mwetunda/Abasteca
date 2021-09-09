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
        public string Localidade { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int Sinal { get; set; }

        public MunicipioDTO Municipio { get; set; }
        public OperadoraDTO Operadora { get; set; }
        public ICollection<SupervisorDTO> Supervisors { get; set; }
    }
    public class BombascriarDTO
    {
        public int OperadoraID { get; set; }
        [Required]
        public int MunicipioID { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
    public class BombasUpdateDTO
    {
        [Required]

        public Guid BombaID { get; set; }
        public int OperadoraID { get; set; }
        [Required]
        public int MunicipioID { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}

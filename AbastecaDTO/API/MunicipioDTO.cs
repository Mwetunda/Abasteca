using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class MunicipioDTO
    {
        public int MunicipioID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int ProvinciaID { get; set; }

        public ProvinciaDTO Provincia { get; set; }
        public ICollection<CondutorDTO> Condutors { get; set; }
        public ICollection<BombasDTO> Bombas { get; set; }
    }
    public class MunicipioDTOcriar
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int ProvinciaID { get; set; }
    }
}

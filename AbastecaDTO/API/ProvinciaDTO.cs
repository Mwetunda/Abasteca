using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class ProvinciaDTO
    {
        public int ProvinciaID { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<MunicipioDTO> Municipios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class CondutorDTO
    {
        public int CondutorID { get; set; }
        [Required]
        public int UsuarioID { get; set; }
        [Required]
        public int MunicipioID { get; set; }

        public UsuarioDTO Usuario { get; set; }
        public MunicipioDTO Municipio { get; set; }
    }
}

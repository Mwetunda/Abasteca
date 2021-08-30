using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class GerenteDTO
    {
        public int GerenteID { get; set; }
        [Required]
        public int UsuarioID { get; set; }

        public UsuarioDTO Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class SupervisorDTO
    {
        public int SupervisorID { get; set; }
        [Required]
        public int UsuarioID { get; set; }
        [Required]
        public int BombaID { get; set; }

        public UsuarioDTO Usuario { get; set; }
        public BombasDTO Bomba { get; set; }
    }
}

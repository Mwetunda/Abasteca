using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class OperadoraDTO
    {
        public int OperadoraID { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<BombasDTO> Bombas { get; set; }
    }
    public class OperadoraCreatDTO
    {
        [Required]
        public string Nome { get; set; }
    }
    public class OperadoraUpdateDTO
    {
        public int OperadoraID { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}

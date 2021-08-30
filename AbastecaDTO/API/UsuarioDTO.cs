using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaDTO.API
{
    public class UsuarioDTO
    {
        public Guid UsuarioID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public int Perfil { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public DateTime DataActualizacao { get; set; }
        public DateTime DataUltimoLogin { get; set; }
    }
    public class UsuarioDTOcriar
    {
        //public Guid UsuarioID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public int Perfil { get; set; }

    }
    public class UsuarioDTOlogin
    {
        public string Telefone { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}

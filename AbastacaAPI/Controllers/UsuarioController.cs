using AbastecaBLL.Interfaces;
using AbastecaDTO.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbastacaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario usuario;

        public UsuarioController(IUsuario _usuario)
        {
            usuario = _usuario;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Insert(UsuarioDTOcriar dto)
        {
            var res = usuario.Insert(dto);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res.Mensagem);
            }
        }
    }
}

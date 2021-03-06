using AbastecaBLL.Interfaces;
using AbastecaDTO.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger<UsuarioController> logger;

        public UsuarioController(IUsuario _usuario, ILogger<UsuarioController> _logger)
        {
            usuario = _usuario;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public IActionResult Insert(UsuarioDTOcriar dto)
        {
            var res = usuario.Insert(dto);

            try
            {
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(res.Mensagem);
                }
            }
            catch(Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao cadastrar usuário");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar(int? page, int? take, string filtro)
        {
            var pagina = page ?? 1;
            var quantidade = take ?? 10;

            try
            {
                var resposta = usuario.List(pagina, quantidade, filtro);

                if (resposta.Exito)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Erro ao gerar lista de usuários");
                }
            }
            catch(Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao gerar lista de usuários");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(UsuarioUpdateDTO dto)
        {
            var res = usuario.Update(dto);

            try
            {
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(res.Mensagem);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao actualizar dados do usuário");
            }
        }
    }
}

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
    public class BombasController : ControllerBase
    {
        private readonly IBombas bombas;
        private ILogger<BombasController> logger;

        public BombasController(IBombas _bombas, ILogger<BombasController> _logger)
        {
            bombas = _bombas;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public IActionResult Insert(BombascriarDTO dto)
        {
            var res = bombas.Insert(dto);

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
                return BadRequest("Erro ao cadastrar bombas");
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
                var resposta = bombas.List(pagina, quantidade, filtro);

                if (resposta.Exito)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Erro ao gerar lista de bombas");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao gerar lista de usuários");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(BombasUpdateDTO dto)
        {
            var res = bombas.Update(dto);

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
                return BadRequest("Erro ao atualizar dados das bombas");
            }
        }
    }
}

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
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvincia provincia;
        private ILogger<ProvinciaController> logger;

        public ProvinciaController(IProvincia _provincia, ILogger<ProvinciaController> _logger)
        {
            provincia = _provincia;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public IActionResult Insert(ProvinciaCreatDTO dto)
        {
            var res = provincia.Insert(dto);

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
                return BadRequest("Erro ao cadastrar província");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {

            try
            {
                var resposta = provincia.List();

                if (resposta.Exito)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Erro ao gerar lista de províncias");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao gerar lista de províncias");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(ProvinciaUpdateDTO dto)
        {
            var res = provincia.Update(dto);

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
                return BadRequest("Erro ao atualizar dados da província");
            }
        }
    }
}

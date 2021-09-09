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
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipio municipio;
        private ILogger<MunicipioController> logger;

        public MunicipioController(IMunicipio _municipio, ILogger<MunicipioController> _logger)
        {
            municipio = _municipio;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public IActionResult Insert(MunicipioDTOcriar dto)
        {
            var res = municipio.Insert(dto);

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
                return BadRequest("Erro ao cadastrar Município");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar(int provinciaId)
        {

            try
            {
                var resposta = municipio.List(provinciaId);

                if (resposta.Exito)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Erro ao gerar lista de municípios");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao gerar lista de municípios");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(MunicipioUpdateDTOcriar dto)
        {
            var res = municipio.Update(dto);

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
                return BadRequest("Erro ao atualizar dados da operadora");
            }
        }
    }
}

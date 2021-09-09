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
    public class OperadoraController : ControllerBase
    {
        private readonly IOperadora operadora;
        private ILogger<OperadoraController> logger;

        public OperadoraController(IOperadora _operadora, ILogger<OperadoraController> _logger)
        {
            operadora = _operadora;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Insert")]
        public IActionResult Insert(OperadoraCreatDTO dto)
        {
            var res = operadora.Insert(dto);

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
                return BadRequest("Erro ao cadastrar Operadora");
            }
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {

            try
            {
                var resposta = operadora.List();

                if (resposta.Exito)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Erro ao gerar lista de operadoras");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return BadRequest("Erro ao gerar lista de operadoras");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(OperadoraUpdateDTO dto)
        {
            var res = operadora.Update(dto);

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

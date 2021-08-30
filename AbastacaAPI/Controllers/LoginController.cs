using AbastacaAPI.Helper;
using AbastecaBLL.Interfaces;
using AbastecaDTO.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbastacaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario login;
        private readonly ILogger<LoginController> iLogger;
        private readonly IOptions<AppConfig> appSettings;

        public LoginController(IUsuario _login, ILogger<LoginController> _iLogger, IOptions<AppConfig> _appSettings)
        {
            login = _login;
            iLogger = _iLogger;
            appSettings = _appSettings;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UsuarioDTOlogin dto)
        {
            try
            {
                var res = login.Login(dto, appSettings.Value.TokenSecret);

                if (res.Exito)
                    return Ok(res);

                return BadRequest(res);
            }
            catch (Exception e)
            {
                iLogger.LogError(e, e.Message);
                return BadRequest("Operação de login falhou");
            }
        }
    }
}

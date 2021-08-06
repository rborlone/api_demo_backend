using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration;
using GlobalErrorHandling.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using APIDemo.Domain.Model.UsuarioAggregate;
using APIDemo.WebApi.Contracts;
using APIDemo.Domain.Common;
using APIDemo.Domain.Facade;

namespace ApiDemo.WebApi.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private IUsuarioService usuarioService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clienteService">Inyectamos la dependencia pasada por el starup.</param>
        /// <param name="logger">Inyectamos el logger.</param>
        public AuthController(IConfiguration configuration, ILogger<AuthController> logger, IUsuarioService usuarioService)
        {
            this._configuration = configuration;
            this._logger = logger;
            this.usuarioService = usuarioService;
        }

        /// <summary>
        /// Metodo para loguearse
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.Usuario.Login)]
        public async Task<IActionResult> Login(UsuarioRequest login)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("AuthController", "Login")
            };

            _logger.LogInformation("AuthController", "Login");

            try
            {
                objResultado.Resultado = await this.usuarioService.LoginUsuarioAsync(login);
            }
            catch (ApiDemoDomainException ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 400;
                _logger.LogWarning(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "400",
                    Descripcion = ex.Message
                };
                objResultado.Errores.Add(objerr);
            }
            catch (ApiDemoLoginException ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 401;
                _logger.LogWarning(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "401",
                    Descripcion = ex.Message
                };

                objResultado.Errores.Add(objerr);
            }
            catch (Exception ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 500;
                _logger.LogCritical(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "500",
                    Descripcion = "Error de procesamiento."
                };
                objResultado.Errores.Add(objerr);
            }

            return StatusCode(_codeStatus, objResultado);
        }

        /// <summary>
        /// Metodo para registrar un usuario
        /// </summary>
        /// <param name="registrarUsuarioRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.Usuario.Registrar)]
        public async Task<IActionResult> Registrar(RegistrarUsuarioRequest registrarUsuarioRequest)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("AuthController", "Renovar")
            };

            _logger.LogInformation("AuthController", "Renovar");

            try
            {
                objResultado.Resultado = await this.usuarioService.RegistrarUsuarioAsync(registrarUsuarioRequest);
            }
            catch (ApiDemoDomainException ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 400;
                _logger.LogWarning(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "400",
                    Descripcion = ex.Message
                };
                objResultado.Errores.Add(objerr);
            }
            catch (Exception ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 500;
                _logger.LogCritical(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "500",
                    Descripcion = "Error de procesamiento."
                };
                objResultado.Errores.Add(objerr);
            }

            return StatusCode(_codeStatus, objResultado);
        }

        /// <summary>
        /// Metodo para realizar la renovacion del token en base al actual.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Usuario.Renovar)]
        public async Task<IActionResult> Renovar()
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("AuthController", "Renovar")
            };

            _logger.LogInformation("AuthController", "Renovar");

            try
            {
                // IdUsuario
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);


                objResultado.Resultado = await this.usuarioService.RenovarTokenAsync(idUsuario);
            }
            catch (ApiDemoDomainException ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 400;
                _logger.LogWarning(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "400",
                    Descripcion = ex.Message
                };
                objResultado.Errores.Add(objerr);
            }
            catch (ApiDemoLoginException ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 401;
                _logger.LogWarning(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "401",
                    Descripcion = ex.Message
                };

                objResultado.Errores.Add(objerr);
            }
            catch (Exception ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 500;
                _logger.LogCritical(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "500",
                    Descripcion = "Error de procesamiento."
                };
                objResultado.Errores.Add(objerr);
            }

            return StatusCode(_codeStatus, objResultado);
        }

        /// <summary>
        /// Metodo para obtener el usuario segun id usuario.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Usuario.ObtenerUsuario)]
        public async Task<IActionResult> ListarUsuarios()
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("AuthController", "Renovar")
            };

            _logger.LogInformation("AuthController", "Renovar");

            try
            {
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);

                objResultado.Resultado = await this.usuarioService.ObtenerUsuarioAsync(idUsuario);
            }
            catch (ApiDemoDomainException ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 400;
                _logger.LogWarning(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "400",
                    Descripcion = ex.Message
                };
                objResultado.Errores.Add(objerr);
            }
            catch (Exception ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 500;
                _logger.LogCritical(ex, "Error de procesamiento Trace { trace }", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "500",
                    Descripcion = "Error de procesamiento."
                };
                objResultado.Errores.Add(objerr);
            }

            return StatusCode(_codeStatus, objResultado);
        }

    }
}

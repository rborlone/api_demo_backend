using APIDemo.Domain.Common;
using APIDemo.Domain.Entity;
using APIDemo.Domain.Model.TareaAggregate;
using APIDemo.Domain.Model.UsuarioAggregate;
using APIDemo.WebApi.Contracts;
using GlobalErrorHandling.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ApiDemo.WebApi.Controllers
{
    [ApiController]
    public class TareaController : ControllerBase
    {

        private readonly ILogger<TareaController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITareaService _tareaService;
        
        public TareaController(IConfiguration configuration, ILogger<TareaController> logger, ITareaService tareaService)
        {
            this._configuration = configuration;
            this._logger = logger;
            this._tareaService = tareaService;
        }

        /// <summary>
        /// Metodo para agregar una tarea.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route(ApiRoutes.Tarea.AgregarTarea)]
        public async Task<IActionResult> AgregarTarea(Tarea tarea)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("TareaController", "AgregarTarea")
            };

            _logger.LogInformation("TareaController", "AgregarTarea");

            try
            {
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);

                objResultado.Resultado = await this._tareaService.AgregarTareaAsync(tarea, idUsuario);
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
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Route(ApiRoutes.Tarea.EliminarTarea)]
        public async Task<IActionResult> EliminarTarea(int idTarea)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("TareaController", "EliminarTarea")
            };

            _logger.LogInformation("TareaController", "EliminarTarea");

            try
            {
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);

                objResultado.Resultado = await this._tareaService.EliminarTareaAsync(idTarea, idUsuario);
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
        /// Metodo para modificar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <param name="estadoTarea"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route(ApiRoutes.Tarea.ModificarTarea)]
        public async Task<IActionResult> CambiarEstadoTarea(int idTarea, EnumEstadoTarea estadoTarea)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("TareaController", "CambiarEstadoTarea")
            };

            _logger.LogInformation("TareaController", "CambiarEstadoTarea");

            try
            {
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);

                objResultado.Resultado = await this._tareaService.CambiarEstadoAsync(idTarea, estadoTarea, idUsuario);
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
        /// Metodo para listar tareas.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Tarea.ListarTarea)]
        public async Task<IActionResult> ListarTarea()
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("TareaController", "ListarTarea")
            };

            _logger.LogInformation("TareaController", "ListarTarea");

            try
            {
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);

                objResultado.Resultado = await this._tareaService.ObtenerListadoTareasAsync(idUsuario);
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
        /// Metodo para obtener una tarea segund id.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Tarea.ObtenerTarea)]
        public async Task<IActionResult> ObtenerTarea(int idTarea)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("TareaController", "ListarTarea")
            };

            _logger.LogInformation("TareaController", "ListarTarea");

            try
            {
                int idUsuario = 0;

                int.TryParse(HttpContext.Items["idUsuario"].ToString(), out idUsuario);

                objResultado.Resultado = await this._tareaService.ObtenerTareaAsync(idTarea, idUsuario);
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

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
                objResultado.Resultado = this._tareaService.AgregarTarea(tarea);
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
                objResultado.Resultado = this._tareaService.EliminarTarea(idTarea);
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
                objResultado.Resultado = this._tareaService.CambiarEstado(idTarea, estadoTarea);
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

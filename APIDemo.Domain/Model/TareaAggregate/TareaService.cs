using APIDemo.Domain.Common;
using APIDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Domain.Model.TareaAggregate
{
    /// <summary>
    /// Clase Service de Tarea.
    /// </summary>
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _repository;
        
        public TareaService(
            ITareaRepository repository
            )
        {
            _repository = repository;
        }
        /// <summary>
        /// Metodo para agregar tareas.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        public Tarea AgregarTarea(Tarea tarea, int idUsuario)
        {
            tarea.IdUsuario = idUsuario;
            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            return _repository.AgregarTarea(tarea);
        }
        /// <summary>
        /// Metodo para cambiar el estado de una tarea en especifico.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <param name="estadoTarea"></param>
        /// <returns></returns>
        public Tarea CambiarEstado(int idTarea, EnumEstadoTarea estadoTarea, int idUsuario)
        {
            var tarea = _repository.ObtenerTarea(idTarea);

            if (tarea == null)
                throw new ApiDemoDomainException("La Tarea no existe.");
            else
                if (tarea.IdUsuario != idUsuario)
                    throw new ApiDemoDomainException("Esta tarea no pertenece al usuario autenticado.");

            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            tarea.EstadoTarea = estadoTarea;
            
            return _repository.ModificarTarea(tarea);
        }
        /// <summary>
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public int EliminarTarea(int idTarea, int idUsuario)
        {
            var tarea = _repository.ObtenerTarea(idTarea);

            if (tarea == null)
                throw new ApiDemoDomainException("La tarea no existe.");
            else
                if (tarea.IdUsuario != idUsuario)
                throw new ApiDemoDomainException("Esta tarea no pertenece al usuario autenticado.");

            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            return _repository.EliminarTarea(idTarea);
        }

        /// <summary>
        /// Metodo para obtener una tarea por id tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public Tarea ObtenerTarea(int idTarea, int idUsuario)
        {

            var tarea = _repository.ObtenerTarea(idTarea);

            if (tarea == null)
                throw new ApiDemoDomainException("La tarea no existe.");
            else
                if (tarea.IdUsuario != idUsuario)
                throw new ApiDemoDomainException("Esta tarea no pertenece al usuario autenticado.");

            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            return tarea;
        }

        /// <summary>
        /// Metodo para obtener una tarea por id tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public IList<Tarea> ObtenerListadoTareas(int idUsuario)
        {
            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            return _repository.ObtenerListadoTarea(idUsuario);
        }

        /// <summary>
        /// Metodo para agregar tareas asincrono.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        public Task<Tarea> AgregarTareaAsync(Tarea tarea, int idUsuario)
        {
            return Task.FromResult<Tarea>(AgregarTarea(tarea, idUsuario));
        }

        /// <summary>
        /// Metodo para cambiar el estado de una tarea en especifico asincrono.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <param name="estadoTarea"></param>
        /// <returns></returns>
        public Task<Tarea> CambiarEstadoAsync(int idTarea, EnumEstadoTarea estadoTarea, int idUsuario)
        {
            return Task.FromResult<Tarea>(CambiarEstado(idTarea, estadoTarea, idUsuario));
        }

        /// <summary>
        /// Metodo para eliminar una tarea asincrono.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public Task<int> EliminarTareaAsync(int idTarea, int idUsuario)
        {
            return Task.FromResult<int>(EliminarTarea(idTarea, idUsuario));
        }

        /// <summary>
        /// Metodo para obtener una tarea por id tarea asincrono.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public Task<Tarea> ObtenerTareaAsync(int idTarea, int idUsuario)
        {
            return Task.FromResult<Tarea>(ObtenerTarea(idTarea, idUsuario));
        }

        /// <summary>
        /// Metodo para obtener un listado de tareas asincrono.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public Task<IList<Tarea>> ObtenerListadoTareasAsync(int idUsuario)
        {
            return Task.FromResult<IList<Tarea>>(ObtenerListadoTareas(idUsuario));
        }
    }
}

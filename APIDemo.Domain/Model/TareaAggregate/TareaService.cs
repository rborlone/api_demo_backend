using APIDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Tarea AgregarTarea(Tarea tarea)
        {
            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            return _repository.AgregarTarea(tarea);
        }
        /// <summary>
        /// Metodo para cambiar el estado de una tarea en especifico.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <param name="estadoTarea"></param>
        /// <returns></returns>
        public Tarea CambiarEstado(int idTarea, EnumEstadoTarea estadoTarea)
        {
            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            Tarea tarea = new Tarea()
            {
                IdTarea = idTarea,
                EstadoTarea = estadoTarea
            };

            return _repository.ModificarTarea(tarea);
        }
        /// <summary>
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public int EliminarTarea(int idTarea)
        {
            //TODO aqui podemos agregar negocio, tales como validaciones u otros..
            return _repository.EliminarTarea(idTarea);
        }
    }
}

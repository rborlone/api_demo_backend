using APIDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Model.TareaAggregate
{
    /// <summary>
    /// Interfaz para trabajar las inyecciones de dependencia de los servicios de tarea.
    /// </summary>
    public interface ITareaService
    {
        /// <summary>
        /// Metodo para agregar tareas.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        Tarea AgregarTarea(Tarea tarea);
       /// <summary>
       /// Metodo para cambiar el estado de una tarea en especifico.
       /// </summary>
       /// <param name="idTarea"></param>
       /// <param name="estadoTarea"></param>
       /// <returns></returns>
        Tarea CambiarEstado(int idTarea, EnumEstadoTarea estadoTarea);

        /// <summary>
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        int EliminarTarea(int idTarea);
    }
}

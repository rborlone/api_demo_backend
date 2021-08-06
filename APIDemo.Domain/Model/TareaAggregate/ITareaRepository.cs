using APIDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Model.TareaAggregate
{
    /// <summary>
    /// Interfaz para trabajar las inyecciones de dependencia de los repositorios de tarea.
    /// </summary>
    public interface ITareaRepository
    {
        /// <summary>
        /// Metodo para agregar tareas.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        Tarea AgregarTarea(Tarea tarea);
        /// <summary>
        /// Metodo para modificar una tarea.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        Tarea ModificarTarea(Tarea tarea);
        /// <summary>
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        int EliminarTarea(int idTarea);
        /// <summary>
        /// Metodo para obtener tareas.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        IList<Tarea> ObtenerTareasPorUsuario(int idTarea);

        /// <summary>
        /// Metodo para obtener un listado de tareas.
        /// </summary>
        /// <returns></returns>
        IList<Tarea> ObtenerListadoTarea(int idUsuario);

        /// <summary>
        /// Metodo para obtener una tarea por id tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        Tarea ObtenerTarea(int idTarea);
    }
}

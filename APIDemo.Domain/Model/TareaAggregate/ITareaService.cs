using APIDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        Tarea AgregarTarea(Tarea tarea, int idUsuario);
       /// <summary>
       /// Metodo para cambiar el estado de una tarea en especifico.
       /// </summary>
       /// <param name="idTarea"></param>
       /// <param name="estadoTarea"></param>
       /// <returns></returns>
        Tarea CambiarEstado(int idTarea, EnumEstadoTarea estadoTarea, int idUsuario);

        /// <summary>
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        int EliminarTarea(int idTarea, int idUsuario);

        /// <summary>
        /// Metodo para obtener una tarea por id tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        Tarea ObtenerTarea(int idTarea, int idUsuario);

        /// <summary>
        /// Metodo para obtener una tarea por id tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        IList<Tarea> ObtenerListadoTareas( int idUsuario);

        /// <summary>
        /// Metodo para agregar tareas (Async).
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        Task<Tarea> AgregarTareaAsync(Tarea tarea, int idUsuario);
        /// <summary>
        /// Metodo para cambiar el estado de una tarea en especifico (Async).
        /// </summary>
        /// <param name="idTarea"></param>
        /// <param name="estadoTarea"></param>
        /// <returns></returns>
        Task<Tarea> CambiarEstadoAsync(int idTarea, EnumEstadoTarea estadoTarea, int idUsuario);

        /// <summary>
        /// Metodo para eliminar una tarea (Async).
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        Task<int> EliminarTareaAsync(int idTarea, int idUsuario);

        /// <summary>
        /// Metodo para obtener una tarea por id tarea (Async).
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        Task<Tarea> ObtenerTareaAsync(int idTarea, int idUsuario);

        /// <summary>
        /// Metodo para obtener una tarea por id tarea (Async).
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        Task<IList<Tarea>> ObtenerListadoTareasAsync(int idUsuario);
    }
}

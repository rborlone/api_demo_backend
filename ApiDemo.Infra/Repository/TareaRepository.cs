using APIDemo.Domain.Entity;
using APIDemo.Domain.Model.TareaAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDemo.Infra.Repository
{
    /// <summary>
    /// Clase Tarea Repositorio.
    /// </summary>
    public class TareaRepository : ITareaRepository
    {
        private readonly DatabaseContext _db;
        private readonly DbSet<Tarea> _dbSet;

        public TareaRepository(DatabaseContext context)
        {
            _db = context;
            _dbSet = _db.Set<Tarea>();
        }
        /// <summary>
        /// Metodo para agregar tareas.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        public Tarea AgregarTarea(Tarea tarea)
        {
            try
            {

                tarea.FechaCreacion = DateTime.Now;

                _dbSet.Add(tarea);
                _db.SaveChanges();

                return tarea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Metodo para modificar una tarea.
        /// </summary>
        /// <param name="tarea"></param>
        /// <returns></returns>
        public int EliminarTarea(int idTarea)
        {
            try
            {
                var resultado = _dbSet.Where(x => x.IdTarea == idTarea).SingleOrDefault();

                if (resultado == null)
                    throw new Exception("No existe la tarea.");

                _dbSet.Remove(resultado);
                _db.SaveChanges();

                return idTarea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Metodo para eliminar una tarea.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public Tarea ModificarTarea(Tarea tarea)
        {
            try
            {
                var resultado = _dbSet.Where(x => x.IdTarea == tarea.IdTarea).SingleOrDefault();

                if (resultado == null)
                    throw new Exception("No existe la tarea.");

                resultado.EstadoTarea = tarea.EstadoTarea;
                resultado.FechaModificacion = DateTime.Now;

                _dbSet.Update(resultado);
                _db.SaveChanges();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para obtener tareas.
        /// </summary>
        /// <param name="idTarea"></param>
        /// <returns></returns>
        public IList<Tarea> ObtenerTareasPorUsuario(int idUsuario)
        {
            try
            {
                var resultado = _dbSet.Where(x => x.IdUsuario == idUsuario).ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

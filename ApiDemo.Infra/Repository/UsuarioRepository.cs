using APIDemo.Domain.Entity;
using APIDemo.Domain.Model.UsuarioAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDemo.Infra.Repository
{
    /// <summary>
    /// Clase repositorio para el trabajo de las conexiones de la base de datos del usuario.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _db;
        private readonly DbSet<Usuario> _dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Recibe el contexto.</param>
        public UsuarioRepository(DatabaseContext context)
        {
            _db = context;
            _dbSet = _db.Set<Usuario>();
        }

        /// <summary>
        /// Metodo para autenticar usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Usuario AutenticarUsuario(string Username)
        {
            try
            {
                var user = _dbSet.SingleOrDefault(x => x.Username == Username);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para obtener una lista de usuarios.
        /// </summary>
        /// <returns></returns>
        public IList<Usuario> ObtenerListaUsuario()
        {
            try
            {
                var resultado = _dbSet.ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para obtener un usuario.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario ObtenerUsuario(int idUsuario)
        {
            try
            {
                var resultado = _dbSet.Where(item => item.IdUsuario == idUsuario).SingleOrDefault();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para registrar usuario.
        /// </summary>
        /// <param name="usuario">Recibe el usuario.</param>
        /// <returns>Retorna el usuario.</returns>
        public Usuario RegistrarUsuario(Usuario usuario)
        {
            try
            {
                _dbSet.Add(usuario);
                _db.SaveChanges();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

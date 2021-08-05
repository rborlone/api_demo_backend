using APIDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Model.UsuarioAggregate
{
    /// <summary>
    /// Interfaz para manejar las inyecciones de dependecias del repositorio de usuario.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Metodo para autenticar usuario
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
       Usuario AutenticarUsuario(string username);
        
        /// <summary>
        /// Metodo para registrar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
       Usuario RegistrarUsuario(Usuario usuario);
        /// <summary>
        /// Metodo para obtener un usuario.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
       Usuario ObtenerUsuario(int idUsuario);
        /// <summary>
        /// Metodo para obtener una lista de usuarios.
        /// </summary>
        /// <returns></returns>
        IList<Usuario> ObtenerListaUsuario();

    }
}

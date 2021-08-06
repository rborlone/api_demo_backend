using APIDemo.Domain.Entity;
using APIDemo.Domain.Facade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Domain.Model.UsuarioAggregate
{
    /// <summary>
    /// Interfaz para el trabajo de inyeccion de la clase Usuario Service.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Metodo para Logear un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        UsuarioResponse LoginUsuario(UsuarioRequest usuario);
        /// <summary>
        /// Metodo para renovar un token
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        UsuarioResponse RenovarToken(int idUsuario);
        /// <summary>
        /// Metodo para registrar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        UsuarioResponse RegistrarUsuario(RegistrarUsuarioRequest usuario);

        /// <summary>
        /// Metodo para obtener un usuario.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        UsuarioListadoResponse ObtenerUsuario(int idUsuario);

        /// <summary>
        /// Metodo para Logear un usuario asincrono
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<UsuarioResponse> LoginUsuarioAsync(UsuarioRequest usuario);
        /// <summary>
        /// Metodo para renovar un token asincrono
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task<UsuarioResponse> RenovarTokenAsync(int idUsuario);
        /// <summary>
        /// Metodo para registrar un usuario asincrono
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<UsuarioResponse> RegistrarUsuarioAsync(RegistrarUsuarioRequest usuario);

        /// <summary>
        /// Metodo para obtener un usuario asincrono
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Task<UsuarioListadoResponse> ObtenerUsuarioAsync(int idUsuario);
    }
}

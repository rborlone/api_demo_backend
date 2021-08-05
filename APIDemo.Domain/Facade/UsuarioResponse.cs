using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Facade
{
    /// <summary>
    /// Clase Facade para retornar la respuesta del usuario.
    /// </summary>
    public class UsuarioResponse
    {
        /// <summary>
        /// IdUsuario
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIDemo.Domain.Facade
{
    /// <summary>
    /// Clase Facade para recibir la peticion del login de usuario
    /// </summary>
    public class UsuarioRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

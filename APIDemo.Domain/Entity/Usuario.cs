using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIDemo.Domain.Entity
{
    /// <summary>
    /// Entidad Usuario.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Id de la tarea.
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password Hash para la encriptación.
        /// </summary>
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        /// <summary>
        /// Password Salt para la encriptación.
        /// </summary>
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        /// <summary>
        /// Nombre del Usuario.
        /// </summary>
        public string Nombre { get; set; }


        public IList<Tarea> listaTarea { get; set; }
    }
}

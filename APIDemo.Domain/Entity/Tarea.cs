using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace APIDemo.Domain.Entity
{
    /// <summary>
    /// Entidad Tarea
    /// </summary>
    public class Tarea
    {
        /// <summary>
        ///  id de la tarea.
        /// </summary>
        public int IdTarea { get; set; }
        /// <summary>
        /// Estado de la tarea.
        /// </summary>
        /// 
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumEstadoTarea EstadoTarea { get; set; }
        /// <summary>
        /// Descripcion de la tarea.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha de Creacion de la tareas.
        /// </summary>
        
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de modificacion.
        /// </summary>
        [JsonIgnore]
        public DateTime FechaModificacion { get; set; }

        public int IdUsuario { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}

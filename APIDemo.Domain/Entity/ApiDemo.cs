using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Entity
{
    /// <summary>
    /// Clase Entidad para trabajar con el Serilog
    /// </summary>
    public class LogApi
    {
        /// <summary>
        /// id del log.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mensaje
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Mensaje con su trace
        /// </summary>
        public string MessageTemplate { get; set; }
        
        /// <summary>
        /// Fecha del log
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; }
        /// <summary>
        /// Excepcion
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// Propiedades.
        /// </summary>
        public string Properties { get; set; }
        /// <summary>
        /// Log Evento.
        /// </summary>
        public string LogEvent { get; set; }
    }
}

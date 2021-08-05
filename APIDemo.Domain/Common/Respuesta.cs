using System;
using System.Collections.Generic;

namespace APIDemo.Domain.Common
{
    /// <summary>
    /// Clase para retornar las respuestas.
    /// </summary>
    public class Respuesta
    {
        /// <summary>
        /// Propiedad Success.
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// Propiedad Trace.
        /// </summary>
        public string Trace { get; set; }

        /// <summary>
        /// Propiedad Resultado.
        /// </summary>
        public Object Resultado { get; set; }

        /// <summary>
        /// Propiedad Lista de Errores.
        /// </summary>
        public IList<Error> Errores { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Respuesta()
        {
            this.Errores = new List<Error>();
        }
    }
}

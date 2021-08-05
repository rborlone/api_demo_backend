using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Common
{
    /// <summary>
    /// Clase para trabajar los errores.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Codigo de error.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Descripcion del error.
        /// </summary>
        public string Descripcion { get; set; }
    }
}

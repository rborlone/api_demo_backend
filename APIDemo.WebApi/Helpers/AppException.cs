using System;
using System.Globalization;

namespace ApiDemo.WebApi.Helpers
{
    /// <summary>
    /// Metodo para manejar las excepciones de la app.
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AppException() : base() { }

        /// <summary>
        /// Constructor SobreCarga +1
        /// </summary>
        /// <param name="message">Recibe el mensaje.</param>
        public AppException(string message) : base(message) { }

        /// <summary>
        /// Constructor SobreCarga +2
        /// </summary>
        /// <param name="message">Recibe el mensaje.</param>
        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
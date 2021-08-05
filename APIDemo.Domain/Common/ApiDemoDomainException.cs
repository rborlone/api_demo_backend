using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Common
{
	/// <summary>
	/// Clase especializada para devolver los errores del backend al front.
	/// </summary>
	public class ApiDemoDomainException : Exception
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ApiDemoDomainException()
		{ }

		/// <summary>
		/// Constructor Sobrecarga +1
		/// </summary>
		/// <param name="message">Recibe el mensaje.</param>
		public ApiDemoDomainException(string message)
			: base(message)
		{ }

		/// <summary>
		/// Constructor Sobrecarga +2
		/// </summary>
		/// <param name="message">Recibe el mensaje.</param>
		/// <param name="innerException"></param>
		public ApiDemoDomainException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}

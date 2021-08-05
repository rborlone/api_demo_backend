using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Model.UsuarioAggregate
{
	/// <summary>
	/// Clase especializada para el control de errores y para retornar errores de tipo Login.
	/// </summary>
    public class ApiDemoLoginException : Exception
    {
		public ApiDemoLoginException()
		{ }

		public ApiDemoLoginException(string message)
			: base(message)
		{ }

		public ApiDemoLoginException(string message, Exception innerException)
			: base(message, innerException)
		{ }
	}
}

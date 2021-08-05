using APIDemo.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

/// <summary>
/// Clase Atributo Autorizado.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public AuthorizeAttribute(){}

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var idUsuario = context.HttpContext.Items["idUsuario"];
        if (idUsuario == null)
        {
            Respuesta objResultado = new Respuesta();

            objResultado.Success = "NOK";

            Error objerr = new Error
            {
                Codigo = "401",
                Descripcion = "Usuario no Autenticado."
            };

            objResultado.Errores.Add(objerr);

            // Esto devuelve el contexto como no autorizado.
            context.Result = new JsonResult(objResultado) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
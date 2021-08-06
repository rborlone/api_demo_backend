using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.WebApi.Contracts
{
    public static class ApiRoutes
    {
        public const string root = "api";
        public const string version = "v1";
        public const string Base = root + "/" + version;

        public static class Usuario
        {
            public const string Login = Base + "/auth";
            public const string Renovar = Base + "/auth/renew";
            public const string Registrar = Base + "/auth/register";
            public const string ObtenerUsuario = Base + "/obtenerUsuario";
        }

        public static class Tarea {
            public const string AgregarTarea = Base + "/tarea";
            public const string EliminarTarea = Base + "/tarea/{idTarea}";
            public const string ModificarTarea = Base + "/tarea/{idTarea}";
            public const string ListarTarea = Base + "/tarea";
            public const string ObtenerTarea = Base + "/tarea/{idTarea}";
        }
    }
}

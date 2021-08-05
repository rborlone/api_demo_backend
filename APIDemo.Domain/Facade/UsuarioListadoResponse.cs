using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Facade
{
    public class UsuarioListadoResponse
    {
        public UsuarioListadoResponse()
        {
            this.Tareas = new List<TareaResponse>();
        }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public List<TareaResponse> Tareas { get; set; }
    }

    public class TareaResponse {
        public int IdTarea { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }

}

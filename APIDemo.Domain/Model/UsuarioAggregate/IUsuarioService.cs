using APIDemo.Domain.Entity;
using APIDemo.Domain.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.Domain.Model.UsuarioAggregate
{
    public interface IUsuarioService
    {
        UsuarioResponse LoginUsuario(UsuarioRequest usuario);
        UsuarioResponse RenovarToken(int idUsuario);
        UsuarioResponse RegistrarUsuario(RegistrarUsuarioRequest usuario);
        UsuarioListadoResponse ObtenerUsuario(int idUsuario);
    }
}

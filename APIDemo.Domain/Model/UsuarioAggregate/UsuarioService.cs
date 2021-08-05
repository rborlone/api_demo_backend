using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using APIDemo.Domain.Common;
using APIDemo.Domain.Entity;
using APIDemo.Domain.Model.TareaAggregate;
using APIDemo.Domain.Facade;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIDemo.Domain.Model.UsuarioAggregate
{
    /// <summary>
    /// Clase Usuario Servicio
    /// </summary>
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ITareaRepository _tareaRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(
            IUsuarioRepository repository,
            IConfiguration configuration,
            ITareaRepository tareaRepository
            )
        {
            _repository = repository;
            _configuration = configuration;
            _tareaRepository = tareaRepository;
        }

        /// <summary>
        /// Metodo para registrar un usuario y dejarlo logueado.
        /// </summary>
        /// <param name="registrarUsuario">Recibe el usuario a registrar.</param>
        /// <returns></returns>
        public UsuarioResponse RegistrarUsuario(RegistrarUsuarioRequest registrarUsuario)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            
            //Verificamos que exista.
            var usuario = _repository.AutenticarUsuario(registrarUsuario.Username);
            
            if (usuario != null)
                throw new ApiDemoDomainException("El usuario ya existe.");
            
            byte[] passwordHash, passwordSalt;

            CrearPasswordHash(registrarUsuario.Password, out passwordHash, out passwordSalt);

            usuario = new Usuario() {
                Nombre = registrarUsuario.Nombre,
                Username = registrarUsuario.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            //Agregamos el usuario.
            usuario = _repository.RegistrarUsuario(usuario);
            
            //Generamos el token.
            string token = generateJwtToken(usuario, secretKey);

            //Retornamos el objeto response.
            UsuarioResponse usuarioResponse = new UsuarioResponse() { 
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Token = token
            };
            
            return usuarioResponse;
        }

        /// <summary>
        /// Metodo login para loguear un usuario.
        /// </summary>
        /// <param name="usuario">Recibe el request del usuario.</param>
        /// <returns></returns>
        public UsuarioResponse LoginUsuario(UsuarioRequest usuario)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");

            var retUsuario = _repository.AutenticarUsuario(usuario.Username);
            
            if (retUsuario == null)
                throw new ApiDemoLoginException("El usuario o la contraseña no es valida.");

            if (!VerificarPassword(usuario.Password, retUsuario.PasswordHash, retUsuario.PasswordSalt))
                throw new ApiDemoLoginException("El usuario o la contraseña no es valida.");

            //Generamos el token.
            string token = generateJwtToken(retUsuario, secretKey);

            //Retornamos el objeto response.
            UsuarioResponse usuarioResponse = new UsuarioResponse()
            {
                IdUsuario = retUsuario.IdUsuario,
                Nombre = retUsuario.Nombre,
                Token = token
            };

            return usuarioResponse;
        }

        public UsuarioResponse RenovarToken(int idUsuario)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");

            var retUsuario = _repository.ObtenerUsuario(idUsuario);

            if (retUsuario == null)
                throw new ApiDemoLoginException("El usuario ya no es valido.");

            //Generamos el token.
            string token = generateJwtToken(retUsuario, secretKey);

            //Retornamos el objeto response.
            UsuarioResponse usuarioResponse = new UsuarioResponse()
            {
                IdUsuario = retUsuario.IdUsuario,
                Nombre = retUsuario.Nombre,
                Token = token
            };

            return usuarioResponse;
        }

        /// <summary>
        /// Metodo para crear el un sha512.
        /// </summary>
        /// <param name="password">Recibe el password.</param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerificarPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // Create hash using password salt.
                for (int i = 0; i < computedHash.Length; i++)
                { // Loop through the byte array
                    if (computedHash[i] != passwordHash[i]) return false; // if mismatch
                }
            }
            return true; //if no mismatches.
        }

        private static byte[] stringToByte(string plaintext)
        {
            return Encoding.UTF8.GetBytes(plaintext);
        }

        private static byte[] hashByte(byte[] arrayBytes)
        {
            return SHA1Managed.Create().ComputeHash(arrayBytes);
        }

        private string generateJwtToken(Usuario usuario, string keystr)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(keystr);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.IdUsuario.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UsuarioListadoResponse ObtenerUsuario(int idUsuario)
        {
            var resultado = _repository.ObtenerUsuario(idUsuario);

            if (resultado == null) {
                return null;
            }

            List<TareaResponse> listaTarea = new List<TareaResponse>();
            var tareas = _tareaRepository.ObtenerTareasPorUsuario(idUsuario);
            if (tareas != null && tareas.Count > 0)
            foreach (var item in tareas)
            {
                    listaTarea.Add(new TareaResponse()
                    {
                        Descripcion = item.Descripcion,
                        Estado = item.EstadoTarea.ToString(),
                        IdTarea = item.IdTarea,
                        FechaCreacion = item.FechaCreacion,
                        FechaModificacion = item.FechaModificacion
                    }); 
            }

            UsuarioListadoResponse respuesta = new UsuarioListadoResponse()
            {
                IdUsuario = resultado.IdUsuario,
                Nombre = resultado.Nombre,
                Tareas = listaTarea
            };

            return respuesta;
        }
    }
}
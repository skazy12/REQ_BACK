
using Aplicacion.DTOs;


namespace Aplicacion.Interfaces.Servicios
{
    public interface ITokenServicio
    {
        string GenerarToken(UsuarioDto usuario);
    }
}

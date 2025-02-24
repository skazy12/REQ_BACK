using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AplicacionDbContext _contexto;

        public UsuarioRepositorio(AplicacionDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario> ObtenerUsuarioPorCodAgendaAsync(string codAgenda)
        {
            return await _contexto.Usuarios
                .Include(u => u.UsuarioCargos)
                .ThenInclude(uc => uc.Cargo)
                .FirstOrDefaultAsync(u => u.CodAgenda == codAgenda);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosActivosAsync()
        {
            return await _contexto.Usuarios
                .Include(u => u.UsuarioCargos)
                .ThenInclude(uc => uc.Cargo)
                .Where(u => u.Activo)
                .ToListAsync();
        }

        public async Task CrearUsuarioAsync(Usuario usuario) // ✅ Implementación del método faltante
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
        }
    }
}

using Aplicacion.DTOs;
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

        public async Task CrearUsuarioAsync(Usuario usuario) 
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<UsuarioDetallesDto>> ObtenerUsuariosConCargosYPermisosDesdeSPAsync()
        {
            var resultado = await _contexto.Database
                .SqlQueryRaw<UsuarioDetalles>(
                    "EXEC ObtenerUsuariosConCargosYPermisos")
                .ToListAsync();

            var usuarios = resultado
                .GroupBy(u => new { u.CodAgenda, u.Nombre })
                .Select(g => new UsuarioDetallesDto
                {
                    CodAgenda = g.Key.CodAgenda,
                    Nombre = g.Key.Nombre,
                    Cargos = g.Select(x => x.Cargo).Distinct().ToList(),
                    Permisos = g.Select(x => x.Permiso).Distinct().ToList()
                }).ToList();

            return usuarios;
        }

    }
}

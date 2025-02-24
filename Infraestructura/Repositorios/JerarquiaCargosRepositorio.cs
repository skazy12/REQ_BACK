using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Repositorios
{
    public class JerarquiaCargosRepositorio : IJerarquiaCargosRepositorio
    {
        private readonly AplicacionDbContext _contexto;

        public JerarquiaCargosRepositorio(AplicacionDbContext contexto)
        {
            _contexto = contexto;
        }

        // 1️⃣ Obtener toda la jerarquía de cargos
        public async Task<IEnumerable<JerarquiaCargos>> ObtenerJerarquiasAsync()
        {
            return await _contexto.JerarquiasCargos.ToListAsync();
        }

        // 2️⃣ Crear una nueva relación jerárquica
        public async Task CrearJerarquiaAsync(JerarquiaCargos jerarquia)
        {
            _contexto.JerarquiasCargos.Add(jerarquia);
            await _contexto.SaveChangesAsync();
        }

        // 3️⃣ Modificar una relación jerárquica existente
        public async Task ModificarJerarquiaAsync(int id, JerarquiaCargos jerarquia)
        {
            var jerarquiaExistente = await _contexto.JerarquiasCargos.FindAsync(id);
            if (jerarquiaExistente != null)
            {
                jerarquiaExistente.CargoIdAsignado = jerarquia.CargoIdAsignado;
                jerarquiaExistente.CargoIdInferior = jerarquia.CargoIdInferior;
                jerarquiaExistente.FechaAsignacion = jerarquia.FechaAsignacion;
                jerarquiaExistente.ModificadoPor = jerarquia.ModificadoPor;
                await _contexto.SaveChangesAsync();
            }
        }

        // 4️⃣ Desactivar una relación jerárquica
        public async Task DesactivarJerarquiaAsync(int id)
        {
            var jerarquia = await _contexto.JerarquiasCargos.FindAsync(id);
            if (jerarquia != null)
            {
                jerarquia.Activo = false;
                await _contexto.SaveChangesAsync();
            }
        }

        // 5️⃣ Obtener los cargos superiores a un cargo específico
        public async Task<IEnumerable<int>> ObtenerCargosSuperioresAsync(int cargoId)
        {
            return await _contexto.JerarquiasCargos
                .Where(j => j.CargoIdInferior == cargoId && j.Activo)
                .Select(j => j.CargoIdAsignado)
                .ToListAsync();
        }

        // 6️⃣ Obtener los cargos subordinados a un cargo específico
        public async Task<IEnumerable<int>> ObtenerCargosInferioresAsync(int cargoId)
        {
            return await _contexto.JerarquiasCargos
                .Where(j => j.CargoIdAsignado == cargoId && j.Activo)
                .Select(j => j.CargoIdInferior.Value)
                .ToListAsync();
        }
    }
}

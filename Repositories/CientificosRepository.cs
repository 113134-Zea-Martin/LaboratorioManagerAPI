using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioManagerAPI.Repositories
{
    public class CientificosRepository : ICientificosRepository
    {
        private readonly LaboratorioDbContext _laboratorioDbContext;

        public CientificosRepository(LaboratorioDbContext laboratorioDbContext)
        {
            _laboratorioDbContext = laboratorioDbContext;
        }
        public async Task<bool> DeleteCientifico(Guid idCientifico)
        {
            var cientifico = await _laboratorioDbContext.Cientificos.FirstOrDefaultAsync(c => c.Id == idCientifico);
            if (cientifico == null)
            {
                return false;
            }
            _laboratorioDbContext.Cientificos.Remove(cientifico);
            await _laboratorioDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExisteCientifico(string nombre, string apellido)
        {
            return await _laboratorioDbContext.Cientificos.AnyAsync(x => x.Nombre == nombre && x.Apellido == apellido);
        }

        public async Task<Cientifico> GetCientificoById(Guid id)
        {
            var cientifico = await _laboratorioDbContext.Cientificos.FirstOrDefaultAsync(x => x.Id ==  id);
            return cientifico;
        }

        public async Task<List<Cientifico>> GetCientificosNoAsignados(Guid idExperimento)
        {
            var idsCientificosEnExperimento = await _laboratorioDbContext.CientificosXexperimentos
                .Where(x => x.ExperimentoId == idExperimento)
                .Select(x => x.CientificoId)
                .ToListAsync();

            var cientificos = await _laboratorioDbContext.Cientificos
                .Where(x => !idsCientificosEnExperimento.Contains(x.Id))
                .ToListAsync();

            return cientificos;
        }

        public async Task<bool> PostCientifico(Cientifico cientifico)
        {
            if (await ExisteCientifico(cientifico.Nombre, cientifico.Apellido))
            {
                return false;
            }

            await _laboratorioDbContext.Cientificos.AddAsync(cientifico);
            await _laboratorioDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PutCientifico(Guid idCientifico, Cientifico cientifico)
        {
            var cientificoAEditar = await _laboratorioDbContext.Cientificos.FirstOrDefaultAsync(x => x.Id == idCientifico);
            if (cientificoAEditar == null)
            {
                return false;
            }

            _laboratorioDbContext.Entry(cientificoAEditar).CurrentValues.SetValues(cientifico);

            await _laboratorioDbContext.SaveChangesAsync();

            return true;
        }

    }
}

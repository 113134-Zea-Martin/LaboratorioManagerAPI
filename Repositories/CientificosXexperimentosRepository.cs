using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioManagerAPI.Repositories
{
    public class CientificosXexperimentosRepository : ICientificosXexperimentosRepository
    {
        private readonly LaboratorioDbContext _laboratorioDbContext;

        public CientificosXexperimentosRepository(LaboratorioDbContext laboratorioDbContext)
        {
            _laboratorioDbContext = laboratorioDbContext;
        }

        public async Task<bool> PostCientificoXExperimentoAsync(CientificosXexperimento cientificosXexperimento)
        {
            var idsCientificosXExperimento = await _laboratorioDbContext.CientificosXexperimentos
                .Where(x => x.ExperimentoId == cientificosXexperimento.ExperimentoId)
                .Select(x => x.CientificoId)
                .ToListAsync();

            if (idsCientificosXExperimento.Contains(cientificosXexperimento.CientificoId))
            {
                return false;
            }

            await _laboratorioDbContext.CientificosXexperimentos.AddAsync(cientificosXexperimento);
            await _laboratorioDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EsCientificoYExperimentoValidosAsync(Guid idCientifico, Guid idExperimento)
        {
            var cientifico = await _laboratorioDbContext.Cientificos.FirstOrDefaultAsync(x => x.Id == idCientifico);
            var experimento = await _laboratorioDbContext.Experimentos.FirstOrDefaultAsync(x => x.Id == idExperimento);

            if (cientifico == null || experimento == null)
            {
                return false;
            }

            return cientifico.Activo && experimento.Activo;
        }
    }
}
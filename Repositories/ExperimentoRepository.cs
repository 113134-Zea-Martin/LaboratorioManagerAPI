using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioManagerAPI.Repositories
{
    public class ExperimentoRepository : IExperimentosRepository
    {
        private readonly LaboratorioDbContext _context;

        public ExperimentoRepository(LaboratorioDbContext context)
        {
            _context = context;
        }
        public async Task<Experimento> DeleteExperimentoAsync(Guid idExperimento)
        {
            var experimento = await _context.Experimentos.FirstOrDefaultAsync(x => x.Id == idExperimento);
            var result = _context.Experimentos.Remove(experimento);
            await _context.SaveChangesAsync();

            return experimento;
        }

        public async Task<bool> ExisteExperimento(Guid idExperimento)
        {
            var result = await _context.Experimentos.AnyAsync(x => x.Id == idExperimento);
            return result;
        }

        public async Task<List<Experimento>> GetExperimentosActivosAsync()
        {
            var lExperimentos = await _context.Experimentos
                .Where(x => x.Activo == true)
                .Include(x => x.CientificosXexperimentos)
                .ToListAsync();

            return lExperimentos;
        }

        public async Task<Experimento> PostExperimentoAsync(Experimento experimento)
        {
            await _context.Experimentos.AddAsync(experimento);
            await _context.SaveChangesAsync();
            return experimento;
        }

        public async Task<bool> PostValidacion(Experimento experimento)
        {
            var result = await _context.Experimentos.AnyAsync(x => x.Nombre == experimento.Nombre);
            return result;
        }

        public async Task<Experimento> PutExperimentoAsync(Guid idExperimento, Experimento experimento)
        {
            var experimentoAEditar = await _context.Experimentos.FirstOrDefaultAsync(x => x.Id == idExperimento);
            _context.Entry(experimentoAEditar).CurrentValues.SetValues(experimento);
            await _context.SaveChangesAsync();
            return experimentoAEditar;
        }
    }
}

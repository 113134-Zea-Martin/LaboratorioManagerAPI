using LaboratorioManagerAPI.Models;

namespace LaboratorioManagerAPI.Repositories.Intefaces
{
    public interface IExperimentosRepository
    {
        Task<List<Experimento>> GetExperimentosActivosAsync();
        Task<Experimento> PostExperimentoAsync(Experimento experimento);
        Task<bool> PostValidacion(Experimento experimento);
        Task<Experimento> PutExperimentoAsync(Guid idExperimento, Experimento experimento);
        Task<bool> ExisteExperimento(Guid idExperimento);
        Task<Experimento> DeleteExperimentoAsync(Guid idExperimento);
    }
}

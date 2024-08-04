using LaboratorioManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioManagerAPI.Repositories.Intefaces
{
    public interface ICientificosRepository
    {
        Task<bool> PostCientifico(Cientifico cientifico);
        Task<bool> ExisteCientifico(string nombre, string apellido);
        Task<List<Cientifico>> GetCientificosNoAsignados(Guid idExperimento);
        Task<bool> PutCientifico(Guid idCientifico, Cientifico cientifico);
        Task<bool> DeleteCientifico(Guid idCientifico);
        Task<Cientifico?> GetCientificoById(Guid id);
    }
}

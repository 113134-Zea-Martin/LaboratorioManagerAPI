using LaboratorioManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LaboratorioManagerAPI.Repositories.Intefaces
{
    public interface ICientificosXexperimentosRepository
    {
        Task<bool> PostCientificoXExperimentoAsync(CientificosXexperimento cientificosXexperimento);

        //Validar que el científico no esté ya asignado al experimento.
        
        Task<bool> EsCientificoYExperimentoValidosAsync(Guid idCientifico, Guid idExperimento);
    }
}

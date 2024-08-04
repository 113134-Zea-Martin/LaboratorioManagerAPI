using LaboratorioManagerAPI.ApiResponse;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;

namespace LaboratorioManagerAPI.Services.Interfaces
{
    public interface ICientificosXExperimentosService
    {
        Task<ApiResponse<PostCientificosXexperimentoDto>> PostCientificoXExperimentoAsync(PostCientificosXexperimentoDto cientificosXexperimentoDto);
    }
}

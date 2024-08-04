using LaboratorioManagerAPI.ApiResponse;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;

namespace LaboratorioManagerAPI.Services.Interfaces
{
    public interface IExperimentosService
    {
        Task<ApiResponse<List<GetExperimentosActivosDto>>> GetExperimentosActivosAsync();
        Task<ApiResponse<Experimento>> PostExperimentoAsync(PostPutExperimentoDto experimentoDto);
        Task<ApiResponse<Experimento>> PutExperimentoAsync(Guid idExperimento, PutExperimentoDto experimentoDto);
        Task<ApiResponse<Guid>> DeleteExperimentoAsync(Guid idExperimento);
    }
}

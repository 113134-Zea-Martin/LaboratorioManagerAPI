using LaboratorioManagerAPI.ApiResponse;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;

namespace LaboratorioManagerAPI.Services.Interfaces
{
    public interface ICientificosService
    {
        Task<ApiResponse<List<Cientifico>>> GetCientificosAfueraDeExperimento(Guid idExperimento);
        Task<ApiResponse<Cientifico>> PostCientificoAsync(CientificoPostDto cientificoDto);
        Task<ApiResponse<Cientifico>> PutCientificoAsync(Guid idCientifico, CientificoPutDto cientificoDto);
        Task<ApiResponse<Cientifico>> DeleteCientificoAsync(Guid idCientifico);
    }
}

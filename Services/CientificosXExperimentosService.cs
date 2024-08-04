using AutoMapper;
using LaboratorioManagerAPI.ApiResponse;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories.Intefaces;
using LaboratorioManagerAPI.Services.Interfaces;

namespace LaboratorioManagerAPI.Services
{
    public class CientificosXExperimentosService : ICientificosXExperimentosService
    {
        private readonly ICientificosXexperimentosRepository _cientificosXexperimentosRepository;
        private readonly IMapper _mapper;

        public CientificosXExperimentosService(ICientificosXexperimentosRepository cientificosXexperimentosRepository, IMapper mapper)
        {
            _cientificosXexperimentosRepository = cientificosXexperimentosRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PostCientificosXexperimentoDto>> PostCientificoXExperimentoAsync(PostCientificosXexperimentoDto cientificosXexperimentoDto)
        {
            ApiResponse<PostCientificosXexperimentoDto> apiResponse = new ApiResponse<PostCientificosXexperimentoDto>();

            var cientificoXExperimento = _mapper.Map<CientificosXexperimento>(cientificosXexperimentoDto);
            cientificoXExperimento.Id = Guid.NewGuid();

            if (!await _cientificosXexperimentosRepository.EsCientificoYExperimentoValidosAsync(cientificoXExperimento.CientificoId, cientificoXExperimento.ExperimentoId))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El cientifico o Experimento no se encuentran activos!";
                return apiResponse;
            }

            if (await _cientificosXexperimentosRepository.PostCientificoXExperimentoAsync(cientificoXExperimento))
            {
                apiResponse.Success = true;
                apiResponse.Data = cientificosXexperimentoDto;
                return apiResponse;
            }

            apiResponse.Success = false;
            apiResponse.Message = "No se asigno el cientifico al experimento";

            return apiResponse;
        }
    }
}

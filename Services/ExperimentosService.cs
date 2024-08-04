using AutoMapper;
using LaboratorioManagerAPI.ApiResponse;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories;
using LaboratorioManagerAPI.Repositories.Intefaces;
using LaboratorioManagerAPI.Services.Interfaces;

namespace LaboratorioManagerAPI.Services
{
    public class ExperimentosService : IExperimentosService
    {
        private readonly IExperimentosRepository _experimentosRepository;
        private readonly IMapper _mapper;

        public ExperimentosService(IExperimentosRepository experimentosRepository, IMapper mapper)
        {
            _experimentosRepository = experimentosRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> DeleteExperimentoAsync(Guid idExperimento)
        {
            ApiResponse<Guid> response = new ApiResponse<Guid>();

            if (await _experimentosRepository.ExisteExperimento(idExperimento))
            {
                await _experimentosRepository.DeleteExperimentoAsync(idExperimento);
                response.Success = true;
                response.Data = idExperimento;
                return response;
            }

            response.Success = false;
            response.Message = "El id ingresado no corresponde a ningun experimento.";
            return response;
        }

        public async Task<ApiResponse<List<GetExperimentosActivosDto>>> GetExperimentosActivosAsync()
        {
            ApiResponse<List<GetExperimentosActivosDto>> response = new ApiResponse<List<GetExperimentosActivosDto>>();
            
            var lExperimentosACtivos = await _experimentosRepository.GetExperimentosActivosAsync();
            var lExperimentosActivosDto = _mapper.Map<List<GetExperimentosActivosDto>>(lExperimentosACtivos);

            if (lExperimentosACtivos != null)
            {
                response.Success = true;
                response.Data = lExperimentosActivosDto;
            } else
            {
                response.Success = false;
                response.Data = null;
                response.Message = "No se encontrar Experimentos activos.";
            }

            return response;
        }

        public async Task<ApiResponse<Experimento>> PostExperimentoAsync(PostPutExperimentoDto experimentoDto)
        {
            ApiResponse<Experimento> response = new ApiResponse<Experimento>();

            var experimento = _mapper.Map<Experimento>(experimentoDto);
            experimento.Activo = true;

            if (await _experimentosRepository.PostValidacion(experimento))
            {
                response.Success = false ;
                response.Message = "El experimento ya se encuentra cargado(Modifique el nombre).";
            }else
            {
                var expCargado = await _experimentosRepository.PostExperimentoAsync(experimento);
                response.Success = true ;
                response.Data = expCargado;
            }
            return response;
        }

        public async Task<ApiResponse<Experimento>> PutExperimentoAsync(Guid idExperimento, PutExperimentoDto experimentoDto)
        {
            ApiResponse<Experimento> response = new ApiResponse<Experimento>();

            var experimentoAEditar = _mapper.Map<Experimento>(experimentoDto);
            experimentoAEditar.Id = idExperimento;

            if(await _experimentosRepository.ExisteExperimento(idExperimento))
            {
                var experimentoEditado = await _experimentosRepository.PutExperimentoAsync(idExperimento, experimentoAEditar);
                response.Success = true ;
                response.Data = experimentoEditado;
                return response;
            }

            response.Success = false;
            response.Message = "El ID ingresado no corresponde a ningun experimento cargado.";

            return response;
        }
    }
}

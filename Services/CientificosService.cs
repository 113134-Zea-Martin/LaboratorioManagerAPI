using AutoMapper;
using LaboratorioManagerAPI.ApiResponse;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories;
using LaboratorioManagerAPI.Repositories.Intefaces;
using LaboratorioManagerAPI.Services.Interfaces;

namespace LaboratorioManagerAPI.Services
{
    public class CientificosService : ICientificosService
    {
        private readonly ICientificosRepository _cientificosRepository;
        private readonly IMapper _mapper;
        private readonly IExperimentosRepository _experimentosRepository;

        public CientificosService(ICientificosRepository cientificosRepository, IMapper mapper, IExperimentosRepository experimentosRepository)
        {
            _cientificosRepository = cientificosRepository;
            _mapper = mapper;
            _experimentosRepository = experimentosRepository;
        }
        public async Task<ApiResponse<Cientifico>> DeleteCientificoAsync(Guid idCientifico)
        {
            ApiResponse<Cientifico> apiResponse = new ApiResponse<Cientifico>();
            var cientifico = await _cientificosRepository.GetCientificoById(idCientifico);
            apiResponse.Data = cientifico;

            if (await _cientificosRepository.DeleteCientifico(idCientifico))
            {
                apiResponse.Success = true;
                apiResponse.Message = "Cientifico Eliminado!";
                return apiResponse;
            }

            apiResponse.Success = false;
            apiResponse.Message = "El cientifico no existe en la base de datos!";

            return apiResponse;
        }

        public async Task<ApiResponse<List<Cientifico>>> GetCientificosAfueraDeExperimento(Guid idExperimento)
        {
            ApiResponse<List<Cientifico>> apiResponse = new ApiResponse<List<Cientifico>>();

            if (!await _experimentosRepository.ExisteExperimento(idExperimento))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El id proporcionado no pertenece a ningun experimento!";
                return apiResponse;
            }

            var cientificos = await _cientificosRepository.GetCientificosNoAsignados(idExperimento);

            if (cientificos != null)
            {
                apiResponse.Success = true;
                apiResponse.Data = cientificos;
                return apiResponse;
            }

            apiResponse.Success = false;
            apiResponse.Message = "No se encontraron cientificos fuera del experimento!";
            return apiResponse;
        }

        public async Task<ApiResponse<Cientifico>> PostCientificoAsync(CientificoPostDto cientificoDto)
        {
            ApiResponse<Cientifico> apiResponse = new ApiResponse<Cientifico>();

            var cientifico = _mapper.Map<Cientifico>(cientificoDto);
            cientifico.Id = Guid.NewGuid();
            cientifico.Activo = true;

            if(await _cientificosRepository.ExisteCientifico(cientificoDto.Nombre, cientificoDto.Apellido))
            {
                apiResponse.Success = false;
                apiResponse.Message = "El cientifico que esta intentando cargar ya existe en la base de datos!";
                return apiResponse;
            }

            if (await _cientificosRepository.PostCientifico(cientifico))
            {
                apiResponse.Success = true;
                apiResponse.Data = cientifico;
                return apiResponse;
            }

            apiResponse.Success = false;
            apiResponse.Message = "No se pudo cargar al cientifico!";
            return apiResponse;
        }

        public async Task<ApiResponse<Cientifico>> PutCientificoAsync(Guid idCientifico, CientificoPutDto cientificoDto)
        {
            ApiResponse<Cientifico> apiResponse = new ApiResponse<Cientifico>();
            var cientifico = _mapper.Map<Cientifico>(cientificoDto);
            cientifico.Id = idCientifico;

            if(await _cientificosRepository.GetCientificoById(idCientifico) == null)
            {
                apiResponse.Success = false;
                apiResponse.Message = "El ID ingresado no corresponde a ningun cientifico cargado.";
                return apiResponse;
            }

            if (await _cientificosRepository.PutCientifico(idCientifico,cientifico))
            {
                apiResponse.Success = true;
                apiResponse.Data = cientifico;
                return apiResponse;
            } else
            {
                apiResponse.Success = false;
                apiResponse.Message = "No se pudo modificar al cientifico";
                return apiResponse;
            }
        }
    }
}

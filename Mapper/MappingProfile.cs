using AutoMapper;
using LaboratorioManagerAPI.Dtos;
using LaboratorioManagerAPI.Models;

namespace LaboratorioManagerAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Experimento, GetExperimentosActivosDto>()
                .ForMember(dest => dest.CantidadCientificos, opt => opt.MapFrom(src => src.CientificosXexperimentos.Count))
                .ReverseMap();

            CreateMap<Experimento, PostPutExperimentoDto>()
                .ReverseMap();

            CreateMap<Experimento, PutExperimentoDto>()
                .ReverseMap();

            CreateMap<Cientifico, CientificoPostDto>()
                .ReverseMap();

            CreateMap<Cientifico, CientificoPutDto>()
                .ReverseMap();

            CreateMap<CientificosXexperimento, PostCientificosXexperimentoDto>()
                .ReverseMap();
        }
    }
}

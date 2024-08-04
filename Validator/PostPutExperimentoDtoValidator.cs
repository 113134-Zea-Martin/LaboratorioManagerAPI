using FluentValidation;
using LaboratorioManagerAPI.Dtos;

namespace LaboratorioManagerAPI.Validator
{
    public class PostPutExperimentoDtoValidator : AbstractValidator<PostPutExperimentoDto>
    {
        public PostPutExperimentoDtoValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Debe ingresar un nombre válido.");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("Debe ingresar una descripcion válida.");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe ingresar un tipo válido.");
            RuleFor(x => x.FechaInicio).NotEmpty().WithMessage("Debe ingresar una fecha de inicio válida.");
            RuleFor(x => x.FechaFin).NotEmpty().WithMessage("Debe ingresar una fecha de fin válida.");
            RuleFor(x => x).Must(x => x.FechaFin >= x.FechaInicio).WithMessage("La fecha de fin debe ser posterior a la fecha de inicio.").When(x => x.FechaInicio.HasValue && x.FechaFin.HasValue);
        }
    }
}

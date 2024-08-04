namespace LaboratorioManagerAPI.Dtos
{
    public class PutExperimentoDto
    {
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string Tipo { get; set; } = null!;

        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }

        public bool Activo { get; set; }
    }
}

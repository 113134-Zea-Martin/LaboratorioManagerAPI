namespace LaboratorioManagerAPI.Dtos
{
    public class PostCientificosXexperimentoDto
    {
        public Guid CientificoId { get; set; }

        public Guid ExperimentoId { get; set; }

        public string? Tarea { get; set; }

        public DateOnly FechaAsignacion { get; set; }
    }
}

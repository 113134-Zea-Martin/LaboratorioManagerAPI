namespace LaboratorioManagerAPI.Dtos
{
    public class CientificoPutDto
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Especialidad { get; set; } = null!;

        public bool Activo { get; set; }
    }
}

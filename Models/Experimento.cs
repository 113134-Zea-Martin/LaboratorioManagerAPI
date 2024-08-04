using System;
using System.Collections.Generic;

namespace LaboratorioManagerAPI.Models;

public partial class Experimento
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Tipo { get; set; } = null!;

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<CientificosXexperimento> CientificosXexperimentos { get; set; } = new List<CientificosXexperimento>();
}

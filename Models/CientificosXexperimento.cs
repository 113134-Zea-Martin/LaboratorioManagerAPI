using System;
using System.Collections.Generic;

namespace LaboratorioManagerAPI.Models;

public partial class CientificosXexperimento
{
    public Guid Id { get; set; }

    public Guid CientificoId { get; set; }

    public Guid ExperimentoId { get; set; }

    public string? Tarea { get; set; }

    public DateOnly FechaAsignacion { get; set; }

    public virtual Cientifico Cientifico { get; set; } = null!;

    public virtual Experimento Experimento { get; set; } = null!;
}

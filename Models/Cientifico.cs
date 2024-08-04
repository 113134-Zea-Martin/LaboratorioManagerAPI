using System;
using System.Collections.Generic;

namespace LaboratorioManagerAPI.Models;

public partial class Cientifico
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<CientificosXexperimento> CientificosXexperimentos { get; set; } = new List<CientificosXexperimento>();
}

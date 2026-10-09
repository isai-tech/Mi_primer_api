using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mi_primer_api.Models;

public partial class Empleado
{
    public int IdEmpleados { get; set; }

    public int IdPuesto { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    [JsonIgnore]
    public virtual Puesto IdPuestoNavigation { get; set; } = null!;
}

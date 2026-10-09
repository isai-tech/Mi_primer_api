using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mi_primer_api.Models;

public partial class Puesto
{
    public int IdPuestos { get; set; }

    public string? Nombre { get; set; }

    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}

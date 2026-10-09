using System;
using System.Collections.Generic;

namespace Mi_primer_api.Models;

public partial class Cliente
{
    public int Idclientes { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Teléfono { get; set; }
}

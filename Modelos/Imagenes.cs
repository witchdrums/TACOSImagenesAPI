using System;
using System.Collections.Generic;

namespace TACOSImagenesAPI.Modelos;

public partial class Imagen
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public byte[]? ImagenBytes { get; set; }
}

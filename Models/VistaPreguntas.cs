using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

[Keyless]
public partial class VistaPreguntas
{
    public int id_pregunta { get; set; }

    public int id_categoria { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? CategoriaDescripcion { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PreguntaDescripcion { get; set; }

    public bool? IsEnabled { get; set; }
}

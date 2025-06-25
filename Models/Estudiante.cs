using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class Estudiante
{
    [Key]
    public int id_estudiante { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Apellidos { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Grupo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Contrasena { get; set; }

    [StringLength(50)]
    public string? Rol { get; set; }
}

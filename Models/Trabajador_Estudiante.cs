using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

[Keyless]
public partial class Trabajador_Estudiante
{
    [StringLength(50)]
    [Unicode(false)]
    public string? Observacion { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Diagnostico { get; set; }

    public int? id_trabajador { get; set; }

    public int? id_estudiante { get; set; }

    [ForeignKey("id_estudiante")]
    public virtual Estudiante? id_estudianteNavigation { get; set; }

    [ForeignKey("id_trabajador")]
    public virtual Trabajador? id_trabajadorNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class Formulario
{
    [Key]
    public int id_formulario { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? folio { get; set; }

    public DateOnly? Fecha { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Respuesta { get; set; }

    public int? id_trabajador { get; set; }

    public int? id_pregunta { get; set; }

    [ForeignKey("id_pregunta")]
    [InverseProperty("Formulario")]
    public virtual Pregunta? id_preguntaNavigation { get; set; }

    [ForeignKey("id_trabajador")]
    [InverseProperty("Formulario")]
    public virtual Trabajador? id_trabajadorNavigation { get; set; }
}

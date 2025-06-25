using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class OpcionesPreguntas
{
    [Key]
    public int IdOpcion { get; set; }

    public int? IdPregunta { get; set; }

    [StringLength(50)]
    public string? Opcion { get; set; }

    [ForeignKey("IdPregunta")]
    [InverseProperty("OpcionesPreguntas")]
    public virtual Pregunta? IdPreguntaNavigation { get; set; }
}

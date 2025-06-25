using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class Pregunta
{
    [Key]
    public int id_pregunta { get; set; }

    public int? id_categoria { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    public bool? IsEnabled { get; set; }

    [InverseProperty("id_preguntaNavigation")]
    public virtual ICollection<Formulario> Formulario { get; set; } = new List<Formulario>();

    [InverseProperty("IdPreguntaNavigation")]
    public virtual ICollection<OpcionesPreguntas> OpcionesPreguntas { get; set; } = new List<OpcionesPreguntas>();

    [ForeignKey("id_categoria")]
    [InverseProperty("Pregunta")]
    public virtual Categoria? id_categoriaNavigation { get; set; }
}

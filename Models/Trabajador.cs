using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class Trabajador
{
    [Key]
    public int id_trabajador { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Apellidos { get; set; }

    public int? Edad { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Sexo { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Estado_Civil { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Escolaridad { get; set; }

    public int? id_empresa { get; set; }

    [InverseProperty("id_trabajadorNavigation")]
    public virtual ICollection<Formulario> Formulario { get; set; } = new List<Formulario>();

    [ForeignKey("id_empresa")]
    [InverseProperty("Trabajador")]
    public virtual Empresa? id_empresaNavigation { get; set; }
}

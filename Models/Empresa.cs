using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final.Models;

public partial class Empresa
{
    [Key]
    public int id_empresa { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [InverseProperty("id_empresaNavigation")]
    public virtual ICollection<Trabajador> Trabajador { get; set; } = new List<Trabajador>();
}

using System;
using System.Collections.Generic;
using Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Final.Context;

public partial class SaludLaboralContext : DbContext
{
    public SaludLaboralContext(DbContextOptions<SaludLaboralContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Empresa> Empresa { get; set; }

    public virtual DbSet<Estudiante> Estudiante { get; set; }

    public virtual DbSet<Formulario> Formulario { get; set; }

    public virtual DbSet<OpcionesPreguntas> OpcionesPreguntas { get; set; }

    public virtual DbSet<Pregunta> Pregunta { get; set; }

    public virtual DbSet<Trabajador> Trabajador { get; set; }

    public virtual DbSet<Trabajador_Estudiante> Trabajador_Estudiante { get; set; }

    public virtual DbSet<VistaPreguntas> VistaPreguntas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.id_categoria).HasName("PK__Categori__CD54BC5A7E847557");

            entity.Property(e => e.Descripcion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Valoracion).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.id_empresa).HasName("PK__Empresa__4A0B7E2C89810474");

            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.id_estudiante).HasName("PK__Estudian__E0B2763CE0427A2D");

            entity.Property(e => e.id_estudiante).ValueGeneratedNever();
            entity.Property(e => e.Apellidos).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Contrasena).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Grupo).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.HasKey(e => e.id_formulario).HasName("PK__Formular__05B111FD6BD88CF7");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Respuesta).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.folio).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.id_pregunta).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.id_trabajador).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.id_preguntaNavigation).WithMany(p => p.Formulario).HasConstraintName("fk_pregunta");

            entity.HasOne(d => d.id_trabajadorNavigation).WithMany(p => p.Formulario).HasConstraintName("fk_trabajador_formulario");
        });

        modelBuilder.Entity<OpcionesPreguntas>(entity =>
        {
            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.OpcionesPreguntas).HasConstraintName("FK_OpcionesPreguntas_Pregunta");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.id_pregunta).HasName("PK__Pregunta__6867FFA498FDB63D");

            entity.Property(e => e.Descripcion).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.id_categoriaNavigation).WithMany(p => p.Pregunta).HasConstraintName("FK_Pregunta_Categoria");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.id_trabajador).HasName("PK__Trabajad__767D20B28ECDBADB");

            entity.Property(e => e.Apellidos).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Edad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Escolaridad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Estado_Civil).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Nombre).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Sexo).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.id_empresa).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.id_empresaNavigation).WithMany(p => p.Trabajador).HasConstraintName("fk_empresa");
        });

        modelBuilder.Entity<Trabajador_Estudiante>(entity =>
        {
            entity.Property(e => e.Diagnostico).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Observacion).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.id_estudiante).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.id_trabajador).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.id_estudianteNavigation).WithMany().HasConstraintName("fk_estudiante");

            entity.HasOne(d => d.id_trabajadorNavigation).WithMany().HasConstraintName("fk_trabajador");
        });

        modelBuilder.Entity<VistaPreguntas>(entity =>
        {
            entity.ToView("VistaPreguntas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

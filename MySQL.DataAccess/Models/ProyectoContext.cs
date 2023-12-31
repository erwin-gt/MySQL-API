﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MySQL.DataAccess.Models;

public partial class ProyectoContext : DbContext
{
    public ProyectoContext()
    {
    }

    public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administracion> Administracions { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Catedratico> Catedraticos { get; set; }

    public virtual DbSet<Colegiatura> Colegiaturas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<HitorialRefreshToken> HitorialRefreshTokens { get; set; }

    public virtual DbSet<Inscripcion> Inscripcions { get; set; }

    public virtual DbSet<Notum> Nota { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Administracion>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PRIMARY");

            entity.ToTable("Administracion");

            entity.HasIndex(e => e.IdRol, "idRol");

            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.Coreo)
                .HasMaxLength(75)
                .HasColumnName("coreo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.FContratacion)
                .HasComment("Fecha de Contratacion")
                .HasColumnName("fContratacion");
            entity.Property(e => e.FNacimiento)
                .HasComment("Fecha de Nacimiento")
                .HasColumnName("fNacimiento");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.PApellido)
                .HasMaxLength(20)
                .HasColumnName("pApellido");
            entity.Property(e => e.PNombre)
                .HasMaxLength(20)
                .HasColumnName("pNombre");
            entity.Property(e => e.SApellido)
                .HasMaxLength(20)
                .HasColumnName("sApellido");
            entity.Property(e => e.SNombre)
                .HasMaxLength(20)
                .HasColumnName("sNombre");
            entity.Property(e => e.Salario)
                .HasPrecision(8, 2)
                .HasColumnName("salario");
            entity.Property(e => e.TNombre)
                .HasMaxLength(20)
                .HasComment("Tercer Nombre si existiese")
                .HasColumnName("tNombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Administracions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Administracion_ibfk_1");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera).HasName("PRIMARY");

            entity.ToTable("Carrera");

            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Catedratico>(entity =>
        {
            entity.HasKey(e => e.IdCatedratico).HasName("PRIMARY");

            entity.ToTable("Catedratico");

            entity.Property(e => e.IdCatedratico).HasColumnName("idCatedratico");
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("direccion");
            entity.Property(e => e.Estatus)
                .HasMaxLength(15)
                .HasComment("Estado en que se encuentra, Activo o Inactivo");
            entity.Property(e => e.FContratacion).HasColumnName("fContratacion");
            entity.Property(e => e.FNacimiento).HasColumnName("fNacimiento");
            entity.Property(e => e.PApellido)
                .HasMaxLength(20)
                .HasColumnName("pApellido");
            entity.Property(e => e.PNombre)
                .HasMaxLength(20)
                .HasColumnName("pNombre");
            entity.Property(e => e.SApellido)
                .HasMaxLength(20)
                .HasColumnName("sApellido");
            entity.Property(e => e.SNombre)
                .HasMaxLength(20)
                .HasColumnName("sNombre");
            entity.Property(e => e.Salario)
                .HasPrecision(8, 2)
                .HasColumnName("salario");
            entity.Property(e => e.TNombre)
                .HasMaxLength(20)
                .HasColumnName("tNombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Colegiatura>(entity =>
        {
            entity.HasKey(e => e.IdColegiatura).HasName("PRIMARY");

            entity.ToTable("Colegiatura");

            entity.HasIndex(e => e.IdCarrera, "idCarrera");

            entity.Property(e => e.IdColegiatura).HasColumnName("idColegiatura");
            entity.Property(e => e.Costo)
                .HasPrecision(8, 2)
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.Mora)
                .HasPrecision(8, 2)
                .HasColumnName("mora");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Colegiaturas)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("Colegiatura_ibfk_1");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PRIMARY");

            entity.ToTable("Curso", tb => tb.HasComment("Cursos Creados"));

            entity.HasIndex(e => e.IdGrado, "idGrado");

            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.CantAlumno)
                .HasComment("Cantidad de Estudiantes registrados al curso")
                .HasColumnName("cantAlumno");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdGrado).HasColumnName("idGrado");
            entity.Property(e => e.NCurso)
                .HasMaxLength(50)
                .HasComment("Nombre del Curso")
                .HasColumnName("nCurso");
            entity.Property(e => e.Seccion)
                .HasMaxLength(1)
                .HasColumnName("seccion");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasComment("Estado el cual se encuentra, Activo, Inactivo o Pendiente");

            entity.HasOne(d => d.IdGradoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdGrado)
                .HasConstraintName("Curso_ibfk_1");

            entity.HasMany(d => d.IdCatedraticos).WithMany(p => p.IdCursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CursoCatedratico",
                    r => r.HasOne<Catedratico>().WithMany()
                        .HasForeignKey("IdCatedratico")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CursoCatedratico_ibfk_2"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CursoCatedratico_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdCurso", "IdCatedratico")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("CursoCatedratico");
                        j.HasIndex(new[] { "IdCatedratico" }, "idCatedratico");
                        j.HasIndex(new[] { "IdCurso", "IdCatedratico" }, "idCurso");
                        j.IndexerProperty<int>("IdCurso").HasColumnName("idCurso");
                        j.IndexerProperty<int>("IdCatedratico").HasColumnName("idCatedratico");
                    });
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PRIMARY");

            entity.ToTable("Estudiante");

            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");
            entity.Property(e => e.CElectronico)
                .HasMaxLength(100)
                .HasColumnName("cElectronico");
            entity.Property(e => e.Carnet)
                .HasMaxLength(10)
                .HasColumnName("carnet");
            entity.Property(e => e.CelEncargado)
                .HasMaxLength(15)
                .HasColumnName("celEncargado");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.FNacimiento).HasColumnName("fNacimiento");
            entity.Property(e => e.NomEncargado)
                .HasMaxLength(100)
                .HasColumnName("nomEncargado");
            entity.Property(e => e.PApellido)
                .HasMaxLength(50)
                .HasColumnName("pApellido");
            entity.Property(e => e.PNombre)
                .HasMaxLength(50)
                .HasColumnName("pNombre");
            entity.Property(e => e.SApellido)
                .HasMaxLength(50)
                .HasColumnName("sApellido");
            entity.Property(e => e.SNombre)
                .HasMaxLength(50)
                .HasColumnName("sNombre");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValueSql("'Pendiente'")
                .HasComment("Estado el cual se encuentra, Activo, Inactivo o Pendiente");
            entity.Property(e => e.TNombre)
                .HasMaxLength(50)
                .HasColumnName("tNombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.IdGrado).HasName("PRIMARY");

            entity.ToTable("Grado");

            entity.HasIndex(e => e.IdCarrera, "idCarrera");

            entity.Property(e => e.IdGrado).HasColumnName("idGrado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.GradoN)
                .HasMaxLength(150)
                .HasColumnName("grado");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Grados)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("Grado_ibfk_1");
        });

        modelBuilder.Entity<HitorialRefreshToken>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PRIMARY");

            entity.ToTable("HitorialRefreshToken");

            entity.HasIndex(e => e.IdUsuario, "idUsuario");

            entity.Property(e => e.IdHistorial).HasColumnName("idHistorial");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("timestamp")
                .HasColumnName("fechaExpiracion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(200)
                .HasColumnName("refreshToken");
            entity.Property(e => e.Token)
                .HasMaxLength(300)
                .HasColumnName("token");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HitorialRefreshTokens)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("idUsuario_FK");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PRIMARY");

            entity.ToTable("Inscripcion");

            entity.HasIndex(e => e.IdAdmin, "idAdmin");

            entity.HasIndex(e => e.IdCarrera, "idCarrera");

            entity.HasIndex(e => e.IdEstudiante, "idEstudiante");

            entity.Property(e => e.IdInscripcion).HasColumnName("idInscripcion");
            entity.Property(e => e.FIncripcion)
                .HasComment(" Fecha de la Inscripcion")
                .HasColumnName("fIncripcion");
            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("Inscripcion_ibfk_3");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("idCarrera_fk");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("idEstudiante");
        });

        modelBuilder.Entity<Notum>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PRIMARY");

            entity.HasIndex(e => e.IdCurso, "idCurso");

            entity.HasIndex(e => e.IdNota, "idNota");

            entity.Property(e => e.IdNota).HasColumnName("idNota");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.Nota).HasColumnName("nota");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("Nota_ibfk_1");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("Puesto");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(25)
                .HasDefaultValueSql("'secund'")
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.FCreacion)
                .HasComment("Fecha Cracion del Usuario")
                .HasColumnName("fCreacion");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(15)
                .HasColumnName("tipoUsuario");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(60)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

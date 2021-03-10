using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaPasantes.Core.Entities;

#nullable disable

namespace SistemaPasantes.Infrastructure
{
    public partial class sistemapasantesContext : DbContext
    {
        public sistemapasantesContext()
        {
        }

        public sistemapasantesContext(DbContextOptions<sistemapasantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Convocatorium> Convocatoria { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<EstadoTarea> EstadoTareas { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<Formulario> Formularios { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Repuestum> Repuesta { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Convocatorium>(entity =>
            {
                entity.ToTable("convocatoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cupo).HasColumnName("cupo");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("date")
                    .HasColumnName("fecha_cierre");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdFormulario).HasColumnName("idFormulario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Convocatoria)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_convocatoria_formulario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Convocatoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_convocatoria_usuario");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.ToTable("entrega");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.RutaArchivo)
                    .HasColumnType("text")
                    .HasColumnName("ruta_archivo");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_entrega_tarea");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_entrega_usuario");
            });

            modelBuilder.Entity<EstadoTarea>(entity =>
            {
                entity.ToTable("estadoTarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("nombre_estado");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("evaluacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFormulario).HasColumnName("idFormulario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluacion_formulario");

                entity.HasOne(d => d.IdUsuario1)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluacion_usuario");
            });

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.ToTable("formulario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ruta");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Repuestum>(entity =>
            {
                entity.ToTable("repuesta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.Data)
                    .HasColumnType("text")
                    .HasColumnName("data");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.IdFormulario).HasColumnName("idFormulario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.TipoRespuesta).HasColumnName("tipo_respuesta");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Repuesta)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_respuesta_formulario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Repuesta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_respuesta_usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("tarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.RutaArchivo)
                    .HasColumnType("text")
                    .HasColumnName("ruta_archivo");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tarea_estadoTarea");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tarea_usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("fk_grupo_usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rol_usuairo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaPasantes.Infrastructure.Data
{
    public partial class SistemaPasantesContext : DbContext
    {
        public SistemaPasantesContext()
        {
        }

        public SistemaPasantesContext(DbContextOptions<SistemaPasantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminEvaluacion> AdminEvaluacions { get; set; }
        public virtual DbSet<Convocatorium> Convocatoria { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<PasanteEvaluacion> PasanteEvaluacions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminEvaluacion>(entity =>
            {
                entity.HasKey(e => e.IdAsignaEvaluacion)
                    .HasName("PK__adminEva__B0AB3F4B92F9194F");

                entity.ToTable("adminEvaluacion");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.AdminEvaluacions)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdEvaluacionRelacionUCE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AdminEvaluacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUsuarioRelacionUCE");
            });

            modelBuilder.Entity<Convocatorium>(entity =>
            {
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
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Convocatoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUsuarioCo");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.ToTable("Entrega");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Archivo)
                    .HasColumnType("text")
                    .HasColumnName("archivo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdTareaUE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUsuarioUE");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("Evaluacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUsuarioE");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("Grupo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<PasanteEvaluacion>(entity =>
            {
                entity.ToTable("PasanteEvaluacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEvaluacion).HasColumnName("idEvaluacion");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.PasanteEvaluacions)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdEvaluacionCE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PasanteEvaluacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUsuarioCE");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaEntreaga)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_entreaga");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.RutaArchivo)
                    .HasColumnType("text")
                    .HasColumnName("ruta_archivo");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Clave).HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdGrupoU");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdRolU");
            });

        
        }
         
    }
}

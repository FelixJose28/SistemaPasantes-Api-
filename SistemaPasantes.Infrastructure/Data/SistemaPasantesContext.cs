using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaPasantes.Core.Entities;
using SistemaPasantes.Infrastructure;

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

        public virtual DbSet<Convocatoria> Convocatoria { get; set; }
        public virtual DbSet<EstadoTarea> EstadoTarea { get; set; }
        public virtual DbSet<Evaluacion> Evaluacion { get; set; }
        public virtual DbSet<Formulario> Formulario { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Pasante> Pasante { get; set; }
        public virtual DbSet<RespuestaFormulario> RespuestaFormulario { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<TareaEntrega> TareaEntrega { get; set; }
        public virtual DbSet<TareaEntregaGrupo> TareaEntregaGrupo { get; set; }
        public virtual DbSet<TipoFormulario> TipoFormulario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Convocatoria>(entity =>
            {
                entity.ToTable("convocatoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cupo).HasColumnName("cupo");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("date")
                    .HasColumnName("fecha_cierre");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAdminUsuario).HasColumnName("idAdminUsuario");

                entity.Property(e => e.IdFormulario).HasColumnName("idFormulario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdAdminUsuarioNavigation)
                    .WithMany(p => p.Convocatoria)
                    .HasForeignKey(d => d.IdAdminUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_convocatoria_usuario");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Convocatoria)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_convocatoria_formulario");
            });

            modelBuilder.Entity<EstadoTarea>(entity =>
            {
                entity.ToTable("estadoTarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre_estado");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("evaluacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("date")
                    .HasColumnName("fecha_cierre");

                entity.Property(e => e.IdAdminUsuario).HasColumnName("idAdminUsuario");

                entity.Property(e => e.IdConvocatoria).HasColumnName("idConvocatoria");

                entity.Property(e => e.IdFormulario).HasColumnName("idFormulario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdAdminUsuarioNavigation)
                    .WithMany(p => p.Evaluacion)
                    .HasForeignKey(d => d.IdAdminUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluacion_usuario");

                entity.HasOne(d => d.IdConvocatoriaNavigation)
                    .WithMany(p => p.Evaluacion)
                    .HasForeignKey(d => d.IdConvocatoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__evaluacio__idCon__656C112C");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.Evaluacion)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evaluacion_formulario");
            });

            modelBuilder.Entity<Formulario>(entity =>
            {
                entity.ToTable("formulario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTipoFormulario).HasColumnName("idTipoFormulario");

                entity.Property(e => e.JsonData)
                    .IsRequired()
                    .HasColumnName("json_data");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdTipoFormularioNavigation)
                    .WithMany(p => p.Formulario)
                    .HasForeignKey(d => d.IdTipoFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__formulari__idTip__619B8048");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdConvocatoria).HasColumnName("idConvocatoria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdConvocatoriaNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.IdConvocatoria)
                    .HasConstraintName("fk_idConvocatoriaG");
            });

            modelBuilder.Entity<Pasante>(entity =>
            {
                entity.ToTable("pasante");

                entity.HasIndex(e => e.IdUsuario, "UQ__pasante__645723A7E3B9A610")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdConvocatoria).HasColumnName("idConvocatoria");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdConvocatoriaNavigation)
                    .WithMany(p => p.Pasante)
                    .HasForeignKey(d => d.IdConvocatoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pasante_convocatoria");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Pasante)
                    .HasForeignKey<Pasante>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pasante_usuario");
            });

            modelBuilder.Entity<RespuestaFormulario>(entity =>
            {
                entity.ToTable("respuestaFormulario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.IdFormulario).HasColumnName("idFormulario");

                entity.Property(e => e.IdTipoRespuesta).HasColumnName("idTipoRespuesta");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.JsonData)
                    .IsRequired()
                    .HasColumnName("json_data");

                entity.HasOne(d => d.IdFormularioNavigation)
                    .WithMany(p => p.RespuestaFormulario)
                    .HasForeignKey(d => d.IdFormulario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_respuesta_formulario");

                entity.HasOne(d => d.IdTipoRespuestaNavigation)
                    .WithMany(p => p.RespuestaFormulario)
                    .HasForeignKey(d => d.IdTipoRespuesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipo_respuesta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RespuestaFormulario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_respuesta_usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("tarea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCierre)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_cierre");

                entity.Property(e => e.IdAdminUsuario).HasColumnName("idAdminUsuario");

                entity.Property(e => e.IdConvocatoria).HasColumnName("idConvocatoria");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdAdminUsuarioNavigation)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.IdAdminUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tarea_usuario_admin");

                entity.HasOne(d => d.IdConvocatoriaNavigation)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.IdConvocatoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tarea__idConvoca__6477ECF3");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tarea_estadoTarea");
            });

            modelBuilder.Entity<TareaEntrega>(entity =>
            {
                entity.ToTable("tareaEntrega");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Archivo).HasColumnName("archivo");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.Comentarios).HasColumnName("comentarios");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_entrega")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Ruta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ruta");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");



                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.TareaEntrega)
                    .HasForeignKey(d => d.IdTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_entrega_tarea");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TareaEntrega)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_entrega_usuario");
            });

            modelBuilder.Entity<TareaEntregaGrupo>(entity =>
            {
                entity.ToTable("tareaEntregaGrupo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.IdTareaEntregada).HasColumnName("idTareaEntregada");

                entity.HasOne(d => d.IdTareaEntregadaNavigation)
                    .WithMany(p => p.TareaEntregaGrupo)
                    .HasForeignKey(d => d.IdTareaEntregada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idTareaEntregadaPorUsuario");
            });

            modelBuilder.Entity<TipoFormulario>(entity =>
            {
                entity.ToTable("tipoFormulario");

                entity.HasIndex(e => e.Nombre, "IX_tipoFormulario")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.Correo, "UQ__usuario__2A586E0B7E4D6093")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .HasColumnName("apellido");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(300)
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
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("fk_grupo_usuario");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rol_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

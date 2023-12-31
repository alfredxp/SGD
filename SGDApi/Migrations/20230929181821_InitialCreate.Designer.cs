﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGDApi.Data;

#nullable disable

namespace SGDApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230929181821_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SGDApi.Models.Estados", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("EstadoCodigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("EstadoNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("SGDApi.Models.LogActividades", b =>
                {
                    b.Property<int>("LogActividadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogActividadId"));

                    b.Property<string>("LogActividadAccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LogActividadFecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("LogActividadId");

                    b.HasIndex("UsuariosUsuarioId");

                    b.ToTable("LogActividades");
                });

            modelBuilder.Entity("SGDApi.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadosEstadoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UsuarioCedula")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UsuarioContrasena")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UsuarioCorreo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime?>("UsuarioFechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UsuarioFechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuarioLlaveQR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioLogin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UsuarioNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UsuarioTelefono")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("UsuarioTwoFactor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.HasKey("UsuarioId");

                    b.HasIndex("EstadosEstadoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SGDApi.Models.LogActividades", b =>
                {
                    b.HasOne("SGDApi.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("SGDApi.Models.Usuarios", b =>
                {
                    b.HasOne("SGDApi.Models.Estados", "Estados")
                        .WithMany("Usuarios")
                        .HasForeignKey("EstadosEstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");
                });

            modelBuilder.Entity("SGDApi.Models.Estados", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}

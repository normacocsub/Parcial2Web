﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ParcialContext))]
    [Migration("20201113003933_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstitucionEducativa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreAcudiente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cedula");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entity.Vacuna", b =>
                {
                    b.Property<string>("NombreVacuna")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CedulaPersona")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EdadAplicacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVacuna")
                        .HasColumnType("datetime2");

                    b.HasKey("NombreVacuna");

                    b.HasIndex("CedulaPersona");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Entity.Vacuna", b =>
                {
                    b.HasOne("Entity.Persona", null)
                        .WithMany()
                        .HasForeignKey("CedulaPersona");
                });
#pragma warning restore 612, 618
        }
    }
}

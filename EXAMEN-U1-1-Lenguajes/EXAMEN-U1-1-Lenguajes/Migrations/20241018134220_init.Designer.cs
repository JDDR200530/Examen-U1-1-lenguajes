﻿// <auto-generated />
using System;
using EXAMEN_U1_1_Lenguajes.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EXAMEN_U1_1_Lenguajes.Migrations
{
    [DbContext(typeof(RequestforPermitsDbContext))]
    [Migration("20241018134220_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EXAMEN_U1_1_Lenguajes.Entity.AdministraitorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_of_Admission")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administraitors");
                });

            modelBuilder.Entity("EXAMEN_U1_1_Lenguajes.Entity.EmpleadoEntity", b =>
                {
                    b.Property<Guid>("id_empleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("Date_of_Admission")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Mail");

                    b.Property<string>("Name_Empleado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name Employee");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Post Employee");

                    b.HasKey("id_empleado");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("EXAMEN_U1_1_Lenguajes.Entity.PermisosEntity", b =>
                {
                    b.Property<Guid>("Id_P")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid?>("EmpleadoEntityid_empleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_Empleado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name_Employed");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("id_empleado")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id_Employed");

                    b.Property<string>("type_of_permit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_P");

                    b.HasIndex("EmpleadoEntityid_empleado");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("EXAMEN_U1_1_Lenguajes.Entity.PermisosEntity", b =>
                {
                    b.HasOne("EXAMEN_U1_1_Lenguajes.Entity.EmpleadoEntity", null)
                        .WithMany("Request")
                        .HasForeignKey("EmpleadoEntityid_empleado");
                });

            modelBuilder.Entity("EXAMEN_U1_1_Lenguajes.Entity.EmpleadoEntity", b =>
                {
                    b.Navigation("Request");
                });
#pragma warning restore 612, 618
        }
    }
}

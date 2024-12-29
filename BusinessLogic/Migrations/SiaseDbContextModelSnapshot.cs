﻿// <auto-generated />
using BusinessLogic.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessLogic.Migrations
{
    [DbContext(typeof(SiaseDbContext))]
    partial class SiaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarreraMateria", b =>
                {
                    b.Property<int>("CarrerasId")
                        .HasColumnType("int");

                    b.Property<int>("MateriasId")
                        .HasColumnType("int");

                    b.HasKey("CarrerasId", "MateriasId");

                    b.HasIndex("MateriasId");

                    b.ToTable("CarreraMateria");
                });

            modelBuilder.Entity("CarreraProfesor", b =>
                {
                    b.Property<int>("CarrerasId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesoresId")
                        .HasColumnType("int");

                    b.HasKey("CarrerasId", "ProfesoresId");

                    b.HasIndex("ProfesoresId");

                    b.ToTable("CarreraProfesor");
                });

            modelBuilder.Entity("Core.Entities.Carrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("Core.Entities.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("Core.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("MateriaProfesor", b =>
                {
                    b.Property<int>("MateriasId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesoresId")
                        .HasColumnType("int");

                    b.HasKey("MateriasId", "ProfesoresId");

                    b.HasIndex("ProfesoresId");

                    b.ToTable("MateriaProfesor");
                });

            modelBuilder.Entity("CarreraMateria", b =>
                {
                    b.HasOne("Core.Entities.Carrera", null)
                        .WithMany()
                        .HasForeignKey("CarrerasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarreraProfesor", b =>
                {
                    b.HasOne("Core.Entities.Carrera", null)
                        .WithMany()
                        .HasForeignKey("CarrerasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Profesor", null)
                        .WithMany()
                        .HasForeignKey("ProfesoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MateriaProfesor", b =>
                {
                    b.HasOne("Core.Entities.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Profesor", null)
                        .WithMany()
                        .HasForeignKey("ProfesoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using AbastecaDAL.EFC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AbastecaDAL.Migrations
{
    [DbContext(typeof(AbastecaContext))]
    partial class AbastecaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbastecaDAL.Entidades.Bomba", b =>
                {
                    b.Property<Guid>("BombaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataActualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MunicipioID")
                        .HasColumnType("int");

                    b.Property<int>("OperadoraID")
                        .HasColumnType("int");

                    b.Property<int>("Sinal")
                        .HasColumnType("int");

                    b.HasKey("BombaID");

                    b.HasIndex("MunicipioID");

                    b.HasIndex("OperadoraID");

                    b.ToTable("Bombas");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Condutor", b =>
                {
                    b.Property<int>("CondutorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MunicipioID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioID1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CondutorID");

                    b.HasIndex("MunicipioID");

                    b.HasIndex("UsuarioID1");

                    b.ToTable("Condutors");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Gerente", b =>
                {
                    b.Property<int>("GerenteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioID1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GerenteID");

                    b.HasIndex("UsuarioID1");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Municipio", b =>
                {
                    b.Property<int>("MunicipioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinciaID")
                        .HasColumnType("int");

                    b.HasKey("MunicipioID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Operadora", b =>
                {
                    b.Property<int>("OperadoraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperadoraID");

                    b.ToTable("Operadoras");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Provincia", b =>
                {
                    b.Property<int>("ProvinciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinciaID");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Supervisor", b =>
                {
                    b.Property<int>("SupervisorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BombaID")
                        .HasColumnType("int");

                    b.Property<Guid?>("BombaID1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<Guid?>("UsuarioID1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SupervisorID");

                    b.HasIndex("BombaID1");

                    b.HasIndex("UsuarioID1");

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataActualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUltimoLogin")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Bomba", b =>
                {
                    b.HasOne("AbastecaDAL.Entidades.Municipio", "Municipio")
                        .WithMany("Bombas")
                        .HasForeignKey("MunicipioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbastecaDAL.Entidades.Operadora", "Operadora")
                        .WithMany("Bombas")
                        .HasForeignKey("OperadoraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");

                    b.Navigation("Operadora");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Condutor", b =>
                {
                    b.HasOne("AbastecaDAL.Entidades.Municipio", "Municipio")
                        .WithMany("Condutors")
                        .HasForeignKey("MunicipioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbastecaDAL.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID1");

                    b.Navigation("Municipio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Gerente", b =>
                {
                    b.HasOne("AbastecaDAL.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID1");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Municipio", b =>
                {
                    b.HasOne("AbastecaDAL.Entidades.Provincia", "Provincia")
                        .WithMany("Municipios")
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Supervisor", b =>
                {
                    b.HasOne("AbastecaDAL.Entidades.Bomba", "Bomba")
                        .WithMany("Supervisors")
                        .HasForeignKey("BombaID1");

                    b.HasOne("AbastecaDAL.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID1");

                    b.Navigation("Bomba");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Bomba", b =>
                {
                    b.Navigation("Supervisors");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Municipio", b =>
                {
                    b.Navigation("Bombas");

                    b.Navigation("Condutors");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Operadora", b =>
                {
                    b.Navigation("Bombas");
                });

            modelBuilder.Entity("AbastecaDAL.Entidades.Provincia", b =>
                {
                    b.Navigation("Municipios");
                });
#pragma warning restore 612, 618
        }
    }
}

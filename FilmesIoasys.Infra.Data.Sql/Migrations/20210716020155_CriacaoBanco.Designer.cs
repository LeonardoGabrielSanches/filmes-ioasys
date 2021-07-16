﻿// <auto-generated />
using System;
using FilmesIoasys.Infra.Data.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmesIoasys.Infra.Data.Sql.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210716020155_CriacaoBanco")]
    partial class CriacaoBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Filme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DiretorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GeneroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sinopse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Genero", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FilmeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Administrador")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Filme", b =>
                {
                    b.HasOne("FilmesIoasys.Dominio.Entidades.Pessoa", "Diretor")
                        .WithMany()
                        .HasForeignKey("DiretorId");

                    b.HasOne("FilmesIoasys.Dominio.Entidades.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId");

                    b.Navigation("Diretor");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Pessoa", b =>
                {
                    b.HasOne("FilmesIoasys.Dominio.Entidades.Filme", null)
                        .WithMany("Atores")
                        .HasForeignKey("FilmeId");
                });

            modelBuilder.Entity("FilmesIoasys.Dominio.Entidades.Filme", b =>
                {
                    b.Navigation("Atores");
                });
#pragma warning restore 612, 618
        }
    }
}

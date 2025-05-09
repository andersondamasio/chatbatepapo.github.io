﻿// <auto-generated />
using System;
using ChatClubeMauiApp.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChatClubeMauiApp.Shared.Migrations
{
    [DbContext(typeof(ChatClubeDbContext))]
    [Migration("20250504220630_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Mensagem.Mensagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SalaId")
                        .HasColumnType("integer");

                    b.Property<int?>("SalasId")
                        .HasColumnType("integer");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("SalasId");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Sala.Salas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("UsuariosOnline")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Sala.SalasUsuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("SalaId")
                        .HasColumnType("integer");

                    b.Property<int>("SalasId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UltimaAtividade")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("SalasUsuarios");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Usuario.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apelido")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("AuthProvider")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("FotoUrl")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("NomeCompleto")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<bool>("Online")
                        .HasColumnType("boolean");

                    b.Property<string>("ProviderId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("SalaId")
                        .HasColumnType("integer");

                    b.Property<int?>("SalasId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Visitantes.Visitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Visitantes");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Mensagem.Mensagens", b =>
                {
                    b.HasOne("ChatClubeMauiApp.Shared.Models.Sala.Salas", "Salas")
                        .WithMany()
                        .HasForeignKey("SalasId");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Sala.SalasUsuarios", b =>
                {
                    b.HasOne("ChatClubeMauiApp.Shared.Models.Sala.Salas", "salas")
                        .WithMany("usuariosNaSala")
                        .HasForeignKey("SalaId");

                    b.HasOne("ChatClubeMauiApp.Shared.Models.Usuario.Usuarios", "usuarios")
                        .WithMany("salasQueParticipa")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("salas");

                    b.Navigation("usuarios");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Usuario.Usuarios", b =>
                {
                    b.HasOne("ChatClubeMauiApp.Shared.Models.Sala.Salas", "salas")
                        .WithMany()
                        .HasForeignKey("SalaId");

                    b.Navigation("salas");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Sala.Salas", b =>
                {
                    b.Navigation("usuariosNaSala");
                });

            modelBuilder.Entity("ChatClubeMauiApp.Shared.Models.Usuario.Usuarios", b =>
                {
                    b.Navigation("salasQueParticipa");
                });
#pragma warning restore 612, 618
        }
    }
}

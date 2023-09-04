﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGL_Cadastru.Repo.DataBase;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230904052014_upd1t")]
    partial class upd1t
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Models.CerereStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CerereId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("Starea")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CerereId");

                    b.ToTable("Stari");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Cerere", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Adaos")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ExecutantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("NrCadastral")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResponsabilId")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ValabilDeLa")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ValabilPanaLa")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ExecutantId");

                    b.HasIndex("ResponsabilId");

                    b.ToTable("Cereri");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Lucrare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CerereId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Pret")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipLucrare")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CerereId");

                    b.ToTable("Lucrari");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Persoana", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DataNasterii")
                        .HasColumnType("TEXT");

                    b.Property<string>("Domiciliu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("IDNP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IDNP")
                        .IsUnique();

                    b.ToTable("Persoane");
                });

            modelBuilder.Entity("Models.CerereStatus", b =>
                {
                    b.HasOne("SIGL_Cadastru.Repo.Models.Cerere", "Cerere")
                        .WithMany("StatusList")
                        .HasForeignKey("CerereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cerere");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Cerere", b =>
                {
                    b.HasOne("SIGL_Cadastru.Repo.Models.Persoana", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGL_Cadastru.Repo.Models.Persoana", "Executant")
                        .WithMany()
                        .HasForeignKey("ExecutantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SIGL_Cadastru.Repo.Models.Persoana", "Responsabil")
                        .WithMany()
                        .HasForeignKey("ResponsabilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Executant");

                    b.Navigation("Responsabil");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Lucrare", b =>
                {
                    b.HasOne("SIGL_Cadastru.Repo.Models.Cerere", "Cerere")
                        .WithMany("Lucrari")
                        .HasForeignKey("CerereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cerere");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Cerere", b =>
                {
                    b.Navigation("Lucrari");

                    b.Navigation("StatusList");
                });
#pragma warning restore 612, 618
        }
    }
}

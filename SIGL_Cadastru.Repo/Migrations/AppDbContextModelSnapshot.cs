﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGL_Cadastru.Repo.DataBase;

#nullable disable

namespace SIGL_Cadastru.Repo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

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

                    b.Property<string>("Nr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NrCadastral")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Portofoliu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResponsabilId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Starea")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("ValabilDeLa")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ValabilPanaLa")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ExecutantId");

                    b.HasIndex("Nr")
                        .IsUnique();

                    b.HasIndex("ResponsabilId");

                    b.ToTable("Cereri");
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

                    b.OwnsOne("SIGL_Cadastru.Repo.ValueObjects.NrCerere", "CerereNr", b1 =>
                        {
                            b1.Property<Guid>("CerereId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Index")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Year")
                                .HasColumnType("INTEGER");

                            b1.HasKey("CerereId");

                            b1.ToTable("Cereri");

                            b1.WithOwner()
                                .HasForeignKey("CerereId");
                        });

                    b.Navigation("CerereNr");

                    b.Navigation("Client");

                    b.Navigation("Executant");

                    b.Navigation("Responsabil");
                });

            modelBuilder.Entity("SIGL_Cadastru.Repo.Models.Cerere", b =>
                {
                    b.Navigation("StatusList");
                });
#pragma warning restore 612, 618
        }
    }
}

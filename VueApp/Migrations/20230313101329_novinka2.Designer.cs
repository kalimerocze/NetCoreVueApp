﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VueApp.Context;

#nullable disable

namespace VueApp.Migrations
{
    [DbContext(typeof(VueAppDbContext))]
    [Migration("20230313101329_novinka2")]
    partial class novinka2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VueApp.Models.Clanek", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nadpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlatneDo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneDo");

                    b.Property<DateTime>("PlatneOd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneOd");

                    b.Property<string>("Poradi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priloha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProPrihlasene")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublikovanoDne")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublikovanoDo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypClanku")
                        .HasColumnType("int");

                    b.Property<DateTime>("VytvorenoDne")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clanek", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistorieClanek");
                                ttb
                                    .HasPeriodStart("PlatneOd")
                                    .HasColumnName("PlatneOd");
                                ttb
                                    .HasPeriodEnd("PlatneDo")
                                    .HasColumnName("PlatneDo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.Novinka", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nadpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlatneDo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneDo");

                    b.Property<DateTime>("PlatneOd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneOd");

                    b.Property<string>("Poradi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priloha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProPrihlasene")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublikovanoDne")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublikovanoDo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypClanku")
                        .HasColumnType("int");

                    b.Property<DateTime>("VytvorenoDne")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Novinka", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistorieNovinka");
                                ttb
                                    .HasPeriodStart("PlatneOd")
                                    .HasColumnName("PlatneOd");
                                ttb
                                    .HasPeriodEnd("PlatneDo")
                                    .HasColumnName("PlatneDo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.Odkaz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlokOdkazu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoveOkno")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PlatneDo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneDo");

                    b.Property<DateTime>("PlatneOd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneOd");

                    b.Property<string>("Popis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Poradi")
                        .HasColumnType("int");

                    b.Property<bool>("ProPrihlasene")
                        .HasColumnType("bit");

                    b.Property<string>("SkupinaOdkazu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypOdkazu")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Zverejnit")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Odkaz", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistorieOdkaz");
                                ttb
                                    .HasPeriodStart("PlatneOd")
                                    .HasColumnName("PlatneOd");
                                ttb
                                    .HasPeriodEnd("PlatneDo")
                                    .HasColumnName("PlatneDo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.Soubor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClanekId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazevSouboru")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlatneDo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneDo");

                    b.Property<DateTime>("PlatneOd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneOd");

                    b.Property<string>("SlozkaSouboru")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Soubor", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistorieSoubor");
                                ttb
                                    .HasPeriodStart("PlatneOd")
                                    .HasColumnName("PlatneOd");
                                ttb
                                    .HasPeriodEnd("PlatneDo")
                                    .HasColumnName("PlatneDo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.TypClanku", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hodnota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlatneDo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneDo");

                    b.Property<DateTime>("PlatneOd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneOd");

                    b.HasKey("Id");

                    b.ToTable("TypClanku", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistorieTypClanku");
                                ttb
                                    .HasPeriodStart("PlatneOd")
                                    .HasColumnName("PlatneOd");
                                ttb
                                    .HasPeriodEnd("PlatneDo")
                                    .HasColumnName("PlatneDo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.TypOdkazu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hodnota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlatneDo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneDo");

                    b.Property<DateTime>("PlatneOd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PlatneOd");

                    b.HasKey("Id");

                    b.ToTable("TypOdkazu", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistorieTypOdkazu");
                                ttb
                                    .HasPeriodStart("PlatneOd")
                                    .HasColumnName("PlatneOd");
                                ttb
                                    .HasPeriodEnd("PlatneDo")
                                    .HasColumnName("PlatneDo");
                            }));
                });
#pragma warning restore 612, 618
        }
    }
}

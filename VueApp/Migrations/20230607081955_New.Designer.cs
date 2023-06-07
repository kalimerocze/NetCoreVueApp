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
    [Migration("20230607081955_New")]
    partial class New
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VueApp.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ForLoggedUserOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishedTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Article", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryArticle");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.ArticleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArticleType", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryArticleType");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryCategory");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Contact", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryContact");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArticleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Folder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("File", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryFile");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlockOfLinks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ForLoggedUserOnly")
                        .HasColumnType("bit");

                    b.Property<string>("GrouOfLinks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OpenToNewWindow")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Link", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryLink");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.LinkType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LinkType", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryLinkType");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("VueApp.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ForLoggedUserOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Order")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishedTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Novinka", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("HistoryNovinka");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });
#pragma warning restore 612, 618
        }
    }
}

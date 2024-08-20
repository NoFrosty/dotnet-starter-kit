﻿// <auto-generated />
using System;
using FSH.Starter.WebApi.English.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.PostgreSQL.English
{
    [DbContext(typeof(EnglishDbContext))]
    [Migration("20240820075310_Removed NPC table")]
    partial class RemovedNPCtable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("english")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FSH.Starter.WebApi.English.Domain.BeanItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AmountOfBeanBeebee")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanBurn")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanCube")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanFurry")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanLuna")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanMuzzy")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanNova")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanOllie")
                        .HasColumnType("integer");

                    b.Property<int>("AmountOfBeanRoxy")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Beans", "english");
                });

            modelBuilder.Entity("FSH.Starter.WebApi.English.Domain.HeartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AmountOfHeart")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Hearts", "english");
                });
#pragma warning restore 612, 618
        }
    }
}

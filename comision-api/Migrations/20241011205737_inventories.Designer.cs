﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ComisionQA;

#nullable disable

namespace ComisionQA.Migrations
{
    [DbContext(typeof(ComisionQaContext))]
    [Migration("20241011205737_inventories")]
    partial class inventories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ComisionQA.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("catalogueId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ComisionQA.Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("ComisionQA.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderDetailId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("orderStatus")
                        .HasColumnType("integer");

                    b.Property<int>("profileId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ComisionQA.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("deliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("detailStatus")
                        .HasColumnType("integer");

                    b.Property<int>("orderId")
                        .HasColumnType("integer");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<double>("total")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("vehicleModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ComisionQA.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("firtsName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("maternal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("paternal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("userID")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ComisionQA.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ComisionQA.Models.SaleHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("detailId")
                        .HasColumnType("integer");

                    b.Property<int>("profileId")
                        .HasColumnType("integer");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("saleDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("totalAmount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("vehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SaleHistories");
                });

            modelBuilder.Entity("ComisionQA.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("rolId")
                        .HasColumnType("integer");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ComisionQA.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderDetailId")
                        .HasColumnType("integer");

                    b.Property<int>("brandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<int>("stock")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("year")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("Vehicle_Models");
                });

            modelBuilder.Entity("ComisionQA.Models.Order", b =>
                {
                    b.HasOne("ComisionQA.Models.OrderDetail", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderDetailId");
                });

            modelBuilder.Entity("ComisionQA.Models.VehicleModel", b =>
                {
                    b.HasOne("ComisionQA.Models.OrderDetail", null)
                        .WithMany("VehicleModels")
                        .HasForeignKey("OrderDetailId");
                });

            modelBuilder.Entity("ComisionQA.Models.OrderDetail", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("VehicleModels");
                });
#pragma warning restore 612, 618
        }
    }
}

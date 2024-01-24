﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using buchhaltungs_service.Model;

#nullable disable

namespace buchhaltungs_service.Migrations
{
    [DbContext(typeof(BuchhaltungsContext))]
    [Migration("20240113212139_mssql.container_migration_942_initCreate")]
    partial class mssqlcontainer_migration_942_initCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("buc")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("buchhaltungs_service.Model.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Activity", "buc");
                });

            modelBuilder.Entity("buchhaltungs_service.Model.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Employee", "buc");
                });

            modelBuilder.Entity("buchhaltungs_service.Model.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("InvoiceText")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("InvoicedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("PaidOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("PaymentTarget")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("PlannedInvoicedOn")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Invoice", "buc");
                });

            modelBuilder.Entity("buchhaltungs_service.Model.Entities.Activity", b =>
                {
                    b.HasOne("buchhaltungs_service.Model.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}

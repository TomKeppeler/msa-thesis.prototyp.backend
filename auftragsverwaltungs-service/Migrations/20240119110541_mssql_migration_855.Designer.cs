﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using auftragsverwaltung_service.Model;

#nullable disable

namespace auftragsverwaltungs_service.Migrations
{
    [DbContext(typeof(AuftragsverwaltungsContext))]
    [Migration("20240119110541_mssql_migration_855")]
    partial class mssql_migration_855
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("auf")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("abrechnungs_service.Model.Entities.Capacity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CapacityPerDay")
                        .HasColumnType("float");

                    b.Property<Guid>("ConsultingRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<double>("DaysOff")
                        .HasColumnType("float");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("PlannedTurnover")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ConsultingRoleId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("Capacity", "auf");
                });

            modelBuilder.Entity("abrechnungs_service.Model.Entities.ConsultingRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("ConsultingRole", "auf");
                });

            modelBuilder.Entity("abrechnungs_service.Model.Entities.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<double>("Effort")
                        .HasColumnType("float");

                    b.Property<Guid?>("MilestoneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("TargetDate")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("MilestoneId");

                    b.ToTable("Feature", "auf");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Customer", "auf");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Milestone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletedOn")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<double?>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Milestone", "auf");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Order", "auf");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Team", "auf");
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

                    b.ToTable("Employee", "auf");
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

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PaidOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("PaymentTarget")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("PlannedInvoicedOn")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Invoice", "auf");
                });

            modelBuilder.Entity("abrechnungs_service.Model.Entities.Capacity", b =>
                {
                    b.HasOne("abrechnungs_service.Model.Entities.ConsultingRole", "ConsultingRole")
                        .WithMany("Capacities")
                        .HasForeignKey("ConsultingRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("buchhaltungs_service.Model.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("auftragsverwaltung_service.Model.Entities.Order", null)
                        .WithMany("Capacities")
                        .HasForeignKey("OrderId");

                    b.Navigation("ConsultingRole");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("abrechnungs_service.Model.Entities.ConsultingRole", b =>
                {
                    b.HasOne("auftragsverwaltung_service.Model.Entities.Order", null)
                        .WithMany("ConsultingRoles")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("abrechnungs_service.Model.Entities.Feature", b =>
                {
                    b.HasOne("auftragsverwaltung_service.Model.Entities.Milestone", null)
                        .WithMany("Features")
                        .HasForeignKey("MilestoneId");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Milestone", b =>
                {
                    b.HasOne("auftragsverwaltung_service.Model.Entities.Order", "Order")
                        .WithMany("Milestones")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Order", b =>
                {
                    b.HasOne("auftragsverwaltung_service.Model.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("buchhaltungs_service.Model.Entities.Employee", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("auftragsverwaltung_service.Model.Entities.Team", "Team")
                        .WithMany("Orders")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Owner");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("buchhaltungs_service.Model.Entities.Invoice", b =>
                {
                    b.HasOne("auftragsverwaltung_service.Model.Entities.Order", null)
                        .WithMany("Invoices")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("abrechnungs_service.Model.Entities.ConsultingRole", b =>
                {
                    b.Navigation("Capacities");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Milestone", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Order", b =>
                {
                    b.Navigation("Capacities");

                    b.Navigation("ConsultingRoles");

                    b.Navigation("Invoices");

                    b.Navigation("Milestones");
                });

            modelBuilder.Entity("auftragsverwaltung_service.Model.Entities.Team", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

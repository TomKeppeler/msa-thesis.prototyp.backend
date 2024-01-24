using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buchhaltungs_service.Migrations
{
    /// <inheritdoc />
    public partial class mssqlcontainer_migration_208_initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "buc");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "buc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "buc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoicedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PlannedInvoicedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PaidOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PaymentTarget = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    InvoiceText = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "buc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "buc",
                        principalTable: "Invoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_InvoiceId",
                schema: "buc",
                table: "Activity",
                column: "InvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity",
                schema: "buc");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "buc");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "buc");
        }
    }
}

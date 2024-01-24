using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auftragsverwaltungs_service.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_855 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auf");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "auf",
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
                name: "Team",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "auf",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "auf",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "auf",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultingRole",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultingRole_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "auf",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoicedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PlannedInvoicedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PaidOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    PaymentTarget = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    InvoiceText = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "auf",
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Milestone",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "DATE", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milestone_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "auf",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capacity",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultingRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlannedTurnover = table.Column<double>(type: "float", nullable: false),
                    DaysOff = table.Column<double>(type: "float", nullable: false),
                    CapacityPerDay = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capacity_ConsultingRole_ConsultingRoleId",
                        column: x => x.ConsultingRoleId,
                        principalSchema: "auf",
                        principalTable: "ConsultingRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Capacity_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "auf",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Capacity_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "auf",
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                schema: "auf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Effort = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    TargetDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    MilestoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature_Milestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalSchema: "auf",
                        principalTable: "Milestone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capacity_ConsultingRoleId",
                schema: "auf",
                table: "Capacity",
                column: "ConsultingRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacity_EmployeeId",
                schema: "auf",
                table: "Capacity",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacity_OrderId",
                schema: "auf",
                table: "Capacity",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingRole_OrderId",
                schema: "auf",
                table: "ConsultingRole",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_MilestoneId",
                schema: "auf",
                table: "Feature",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OrderId",
                schema: "auf",
                table: "Invoice",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_OrderId",
                schema: "auf",
                table: "Milestone",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "auf",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OwnerId",
                schema: "auf",
                table: "Order",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TeamId",
                schema: "auf",
                table: "Order",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacity",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Feature",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "ConsultingRole",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Milestone",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "auf");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "auf");
        }
    }
}

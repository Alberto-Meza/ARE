using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARE.API.Migrations
{
    /// <inheritdoc />
    public partial class M008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CivilStatus_CivilStatusID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_CivilStatus_CivilStatusId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilStatus",
                table: "CivilStatus");

            migrationBuilder.RenameTable(
                name: "CivilStatus",
                newName: "CivilStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilStatuses",
                table: "CivilStatuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MethodOfPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodOfPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PendingCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssistanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendingCharges_Assistances_AssistanceId",
                        column: x => x.AssistanceId,
                        principalTable: "Assistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTypeOfCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfChargeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTypeOfCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTypeOfCharges_TypeOfCharges_TypeOfChargeId",
                        column: x => x.TypeOfChargeId,
                        principalTable: "TypeOfCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubTypeOfChargeId = table.Column<int>(type: "int", nullable: false),
                    ChargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charges_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Charges_SubTypeOfCharges_SubTypeOfChargeId",
                        column: x => x.SubTypeOfChargeId,
                        principalTable: "SubTypeOfCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChargeDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPending = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargeDates_Charges_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChargeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargeId = table.Column<int>(type: "int", nullable: false),
                    MethodOfPaymentId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargeDetails_Charges_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargeDetails_MethodOfPayments_MethodOfPaymentId",
                        column: x => x.MethodOfPaymentId,
                        principalTable: "MethodOfPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CivilStatuses_Name",
                table: "CivilStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChargeDates_ChargeId",
                table: "ChargeDates",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeDetails_ChargeId",
                table: "ChargeDetails",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeDetails_MethodOfPaymentId",
                table: "ChargeDetails",
                column: "MethodOfPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Charges_StudentId",
                table: "Charges",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Charges_SubTypeOfChargeId",
                table: "Charges",
                column: "SubTypeOfChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodOfPayments_Name",
                table: "MethodOfPayments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendingCharges_AssistanceId",
                table: "PendingCharges",
                column: "AssistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeOfCharges_TypeOfChargeId",
                table: "SubTypeOfCharges",
                column: "TypeOfChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CivilStatuses_CivilStatusID",
                table: "Employees",
                column: "CivilStatusID",
                principalTable: "CivilStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CivilStatuses_CivilStatusId",
                table: "Students",
                column: "CivilStatusId",
                principalTable: "CivilStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CivilStatuses_CivilStatusID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_CivilStatuses_CivilStatusId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ChargeDates");

            migrationBuilder.DropTable(
                name: "ChargeDetails");

            migrationBuilder.DropTable(
                name: "PendingCharges");

            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "MethodOfPayments");

            migrationBuilder.DropTable(
                name: "SubTypeOfCharges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilStatuses",
                table: "CivilStatuses");

            migrationBuilder.DropIndex(
                name: "IX_CivilStatuses_Name",
                table: "CivilStatuses");

            migrationBuilder.RenameTable(
                name: "CivilStatuses",
                newName: "CivilStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilStatus",
                table: "CivilStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CivilStatus_CivilStatusID",
                table: "Employees",
                column: "CivilStatusID",
                principalTable: "CivilStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CivilStatus_CivilStatusId",
                table: "Students",
                column: "CivilStatusId",
                principalTable: "CivilStatus",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARE.API.Migrations
{
    /// <inheritdoc />
    public partial class M012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "ChargeDates");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "PendingCharges",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubTypeOfChargeId",
                table: "PendingCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "PendingCharges",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Charges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChargeId",
                table: "Assistances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Assistances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PendingCharges_SubTypeOfChargeId",
                table: "PendingCharges",
                column: "SubTypeOfChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistances_ChargeId",
                table: "Assistances",
                column: "ChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistances_Charges_ChargeId",
                table: "Assistances",
                column: "ChargeId",
                principalTable: "Charges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PendingCharges_SubTypeOfCharges_SubTypeOfChargeId",
                table: "PendingCharges",
                column: "SubTypeOfChargeId",
                principalTable: "SubTypeOfCharges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assistances_Charges_ChargeId",
                table: "Assistances");

            migrationBuilder.DropForeignKey(
                name: "FK_PendingCharges_SubTypeOfCharges_SubTypeOfChargeId",
                table: "PendingCharges");

            migrationBuilder.DropIndex(
                name: "IX_PendingCharges_SubTypeOfChargeId",
                table: "PendingCharges");

            migrationBuilder.DropIndex(
                name: "IX_Assistances_ChargeId",
                table: "Assistances");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "PendingCharges");

            migrationBuilder.DropColumn(
                name: "SubTypeOfChargeId",
                table: "PendingCharges");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PendingCharges");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Charges");

            migrationBuilder.DropColumn(
                name: "ChargeId",
                table: "Assistances");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assistances");

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "ChargeDates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

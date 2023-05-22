using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARE.API.Migrations
{
    /// <inheritdoc />
    public partial class M001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "ChargeDetails",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentDate",
                table: "ChargeDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}

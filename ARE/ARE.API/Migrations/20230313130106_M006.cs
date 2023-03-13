using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARE.API.Migrations
{
    /// <inheritdoc />
    public partial class M006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FingertPrint1",
                table: "Employees",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "FingertPrint2",
                table: "Employees",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Employees",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfCharges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Asthma = table.Column<bool>(type: "bit", nullable: false),
                    Convulsions = table.Column<bool>(type: "bit", nullable: false),
                    OtherConditions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Diseases = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Medicines = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FirstDateAppointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fingerprint1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Fingerprint2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameTutor1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BirthDateTutor1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CelNumberTutor1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccupationTutor1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipTutor1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameTutor2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BirthDateTutor2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CelNumberTutor2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccupationTutor2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipTutor2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodTypeId = table.Column<int>(type: "int", nullable: true),
                    CivilStatusId = table.Column<int>(type: "int", nullable: true),
                    SchoolGradeId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_BloodTypes_BloodTypeId",
                        column: x => x.BloodTypeId,
                        principalTable: "BloodTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_CivilStatus_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "CivilStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_SchoolGrades_SchoolGradeId",
                        column: x => x.SchoolGradeId,
                        principalTable: "SchoolGrades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTypeRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTypeRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTypeRelationships_StudentTypes_StudentTypeId",
                        column: x => x.StudentTypeId,
                        principalTable: "StudentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTypeRelationships_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assistances_EntryDate_StudentId",
                table: "Assistances",
                columns: new[] { "EntryDate", "StudentId" },
                unique: true,
                filter: "[EntryDate] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assistances_StudentId",
                table: "Assistances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTypes_Name",
                table: "BloodTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGrades_Name",
                table: "SchoolGrades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_BloodTypeId",
                table: "Students",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CityId",
                table: "Students",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CivilStatusId",
                table: "Students",
                column: "CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolGradeId",
                table: "Students",
                column: "SchoolGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTypeRelationships_StudentId",
                table: "StudentTypeRelationships",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTypeRelationships_StudentTypeId",
                table: "StudentTypeRelationships",
                column: "StudentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTypes_Name",
                table: "StudentTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfCharges_Name",
                table: "TypeOfCharges",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistances");

            migrationBuilder.DropTable(
                name: "StudentTypeRelationships");

            migrationBuilder.DropTable(
                name: "TypeOfCharges");

            migrationBuilder.DropTable(
                name: "StudentTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "BloodTypes");

            migrationBuilder.DropTable(
                name: "SchoolGrades");

            migrationBuilder.DropColumn(
                name: "FingertPrint1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FingertPrint2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Employees");
        }
    }
}

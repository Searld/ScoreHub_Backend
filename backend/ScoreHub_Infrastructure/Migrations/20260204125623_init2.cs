using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreHub_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mkns",
                columns: table => new
                {
                    MknId = table.Column<Guid>(type: "uuid", nullable: false),
                    RawScores = table.Column<double>(type: "double precision", nullable: false),
                    FirstModuleScores = table.Column<double>(type: "double precision", nullable: false),
                    SecondModuleScores = table.Column<double>(type: "double precision", nullable: false),
                    ThirdModuleScores = table.Column<double>(type: "double precision", nullable: false),
                    FinalScores = table.Column<double>(type: "double precision", nullable: false),
                    RawMark = table.Column<double>(type: "double precision", nullable: false),
                    FinalMark = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mkns", x => x.MknId);
                });

            migrationBuilder.CreateTable(
                name: "LessonMkns",
                columns: table => new
                {
                    LessonMknId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonMknNumber = table.Column<int>(type: "integer", nullable: false),
                    Scores = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    AdditionalCoefficient = table.Column<double>(type: "double precision", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsStudentAttended = table.Column<bool>(type: "boolean", nullable: false),
                    MknId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonMkns", x => x.LessonMknId);
                    table.ForeignKey(
                        name: "FK_LessonMkns_Mkns_MknId",
                        column: x => x.MknId,
                        principalTable: "Mkns",
                        principalColumn: "MknId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    MknId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Mkns_MknId",
                        column: x => x.MknId,
                        principalTable: "Mkns",
                        principalColumn: "MknId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonMkns_MknId",
                table: "LessonMkns",
                column: "MknId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MknId",
                table: "Students",
                column: "MknId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonMkns");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Mkns");
        }
    }
}

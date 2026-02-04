using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreHub_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullPossibleMkn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Mkns_MknId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "MknId",
                table: "Students",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Mkns_MknId",
                table: "Students",
                column: "MknId",
                principalTable: "Mkns",
                principalColumn: "MknId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Mkns_MknId",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "MknId",
                table: "Students",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Mkns_MknId",
                table: "Students",
                column: "MknId",
                principalTable: "Mkns",
                principalColumn: "MknId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

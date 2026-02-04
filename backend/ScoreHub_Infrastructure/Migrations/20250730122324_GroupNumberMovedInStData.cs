using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreHub_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GroupNumberMovedInStData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "GroupNumber",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "GroupNumber",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomApi.Migrations
{
    /// <inheritdoc />
    public partial class AddYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Livingcosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Livingcosts");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Incomes");
        }
    }
}

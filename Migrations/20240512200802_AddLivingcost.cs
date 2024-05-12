using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLivingcost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livingcosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsBaseline = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Mortgage = table.Column<int>(type: "int", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false),
                    Loans = table.Column<int>(type: "int", nullable: false),
                    Utilities = table.Column<int>(type: "int", nullable: false),
                    Education = table.Column<int>(type: "int", nullable: false),
                    Markets = table.Column<int>(type: "int", nullable: false),
                    Transportation = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livingcosts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livingcosts");
        }
    }
}

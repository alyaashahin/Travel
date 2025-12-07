using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceApi.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "country",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "state",
                table: "hotels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "hotels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "hotels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "hotels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}

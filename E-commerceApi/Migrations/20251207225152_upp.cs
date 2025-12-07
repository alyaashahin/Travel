using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceApi.Migrations
{
    /// <inheritdoc />
    public partial class upp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image_gallery",
                table: "hotels",
                newName: "ImageGallery");

            migrationBuilder.AlterColumn<string>(
                name: "ImageGallery",
                table: "hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageGallery",
                table: "hotels",
                newName: "image_gallery");

            migrationBuilder.AlterColumn<string>(
                name: "image_gallery",
                table: "hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
